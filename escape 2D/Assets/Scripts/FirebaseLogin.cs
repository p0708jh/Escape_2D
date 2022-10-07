using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using LitJson;
using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Firebase.Auth;
#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;

using Firebase;
#elif UNITY_IOS
using System.Text;
using Google;
using UnityEngine.SignInWithApple;
#endif



public class FirebaseLogin : MonoBehaviour
{
    readonly string URL = "https://6mur5vhowg.execute-api.us-east-1.amazonaws.com/2021-01-02/ranking/";

    public Text userName;
    public static string imageUrl;
    static public string Email = "OandOne@gmail.com";
    public int saveStage = 0;
    [System.Serializable]
    public class SendData
    {
        public string name;
        public int stage;
        public float clearTime;
        public string email;
        public string mode;
        public int stageIndex;
        public float stageClearTime;
        public string imageUrl;
    }

    SendData data = new SendData();
    private FirebaseAuth auth;
#if UNITY_ANDROID
    
    FederatedOAuthProviderData providerData;
    private AndroidJavaObject ajo;
    
    void Awake()
    {
        //Debug.Log(Application.version);

        saveStage = 0;
        //imageUrl ="https://www.oandone.com/images/1.jpg";

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .RequestEmail()
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
 


        //GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);



        ajo = new AndroidJavaObject("com.company.escape2d.UKakao");
        
        // 구글 플레이 게임 활성화
        
        auth = FirebaseAuth.DefaultInstance; // Firebase 엑세스 API 호출

        //유저 데이터 초기화


        if (PlayerPrefs.HasKey("name"))
        {
            userName.text = PlayerPrefs.GetString("name");
            Email = PlayerPrefs.GetString("email");
            imageUrl = PlayerPrefs.GetString("imageUrl");
        }
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();

        data.stage = 0;
        data.clearTime = 0;
        data.mode = "timeattack";
        data.stageIndex = 0;
        data.stageClearTime = 0;

    }

    public void FireLoginEmail()
    {
        auth.CreateUserWithEmailAndPasswordAsync("OandOne234@gmail.com", "oandone").ContinueWith(task => {
            if (task.IsCanceled)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
        });
    }



    public void TryGoogleLogin()
    {

        saveStage = 0;
        if (Social.localUser.authenticated) // 로그인 되어 있다면
        {
            PlayGamesPlatform.Instance.SignOut(); // Google 로그아웃
            auth.SignOut(); // Firebase 로그아웃
        }

        if (!Social.localUser.authenticated) // 로그인 되어 있지 않다면
        {
            Social.localUser.Authenticate(success => // 로그인 시도
            {
                if (success) // 성공하면
                {
                    //userName.text = Social.localUser.userName;
                    StartCoroutine(TryFirebaseGoogleLogin()); // Firebase Login 시도
                }
                /*
                else // 실패하면
                {
                    userName.text = "Fail...";
                }
                */
            });
        }
    }

    

   



    IEnumerator TryFirebaseGoogleLogin()
    {
        PlayerPrefs.DeleteAll();
        while (string.IsNullOrEmpty(((PlayGamesLocalUser)Social.localUser).GetIdToken()))
            yield return null;
        string idToken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();


        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                //userName.text = "파이어 베이스 연동 취소됨";
                return;
            }
            if (task.IsFaulted)
            {
                //userName.text = "파이어 베이스 연동 오류";
                return;
            }

            Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            
                string name = user.DisplayName;
                Email = user.Email;
            
            System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
            
            userName.text = Social.localUser.userName;
            
            PlayerPrefs.SetString("name", Social.localUser.userName);
            PlayerPrefs.SetString("email", user.Email);
            PlayerPrefs.SetString("imageUrl", user.PhotoUrl.ToString());

            PlayerPrefs.Save();
            

            data.email = Email;
            data.name = Social.localUser.userName;

            

            data.imageUrl = user.PhotoUrl.ToString();
            imageUrl = user.PhotoUrl.ToString();

            Task.Factory.StartNew(() => { Send(data); });


            //userName.text= user.PhotoUrl.ToString();

            //userName.text =email;
        });
    }


    public void TryAppleLogin()
    {
        saveStage = 0;
        TryFirebaseAppleLogin();
    }

    private void TryFirebaseAppleLogin()
    {
        PlayerPrefs.DeleteAll();
        providerData = new FederatedOAuthProviderData();
        providerData.ProviderId = "apple.com";

        providerData.Scopes = new List<string>
        {
            "email",
            "name",

        };

        FederatedOAuthProvider provider = new FederatedOAuthProvider();
        provider.SetProviderData(providerData);


        auth.SignInWithProviderAsync(provider).ContinueWith(task => {
            if (task.IsCanceled)
            {
                //userName.text = "파이어 베이스 연동 취소됨";
                return;
            }
            if (task.IsFaulted)
            {
                //userName.text = "파이어 베이스 연동 오류"+ task.Exception;
                //Debug.Log(task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null)
            {
                
                string name = user.DisplayName;
                string email = user.Email;
                System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
                //ImageUrl = photo_url;
                Email = user.Email;
                
                userName.text =name;

                PlayerPrefs.SetString("name", user.DisplayName);
                PlayerPrefs.SetString("email", user.Email);
                PlayerPrefs.SetString("imageUrl", user.PhotoUrl.ToString());

                PlayerPrefs.Save();
                


                data.email = Email;
                data.name = user.DisplayName;


                
                data.imageUrl = user.PhotoUrl.ToString();
                imageUrl = user.PhotoUrl.ToString();

                Task.Factory.StartNew(() => { Send(data); });

            }

            

            /*SignInResult signInResult = task.Result;
            FirebaseUser user = signInResult.User;
            
        

            string name = user.DisplayName;
            Email = user.Email;
            System.Uri photo_url = user.PhotoUrl;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = user.UserId;
            */


            //userName.text =email;
        });
    }


    public void TryKakaoLogin()
    {
        PlayerPrefs.DeleteAll();
        saveStage = 0;
        //public string Get<string>("KakaoLogin");
        ajo.Call("KakaoLogin");

        
        

        
        
    }


    private void SetName(string name)
    {
        userName.text = name;
        data.name = name;

        PlayerPrefs.SetString("name", name);

    }

    private void SetEmail(string email)
    {
        data.email = email;
        Email = email;
        PlayerPrefs.SetString("email", email);
        //userName.text = PlayerPrefs.GetString("email");
        PlayerPrefs.Save();
    }
    private void SetImage(string imageData)
    {
        data.imageUrl = imageData;
        imageUrl = imageData;
        PlayerPrefs.SetString("imageUrl", imageData);
        Task.Factory.StartNew(() => { Send(data); });
    }
#elif UNITY_IOS
    private GoogleSignInConfiguration configuration;
    private string userId, userIdToken, appleName;
    void Awake()
    {
        //Debug.Log(Application.version);
        auth = FirebaseAuth.DefaultInstance; // Firebase 엑세스 API 호출
        saveStage = 0;
        //imageUrl ="https://www.oandone.com/images/1.jpg";

        if (PlayerPrefs.HasKey("name"))
        {
            userName.text = PlayerPrefs.GetString("name");
            Email = PlayerPrefs.GetString("email");
            imageUrl = PlayerPrefs.GetString("imageUrl");
        }
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();

        data.stage = 0;
        data.clearTime = 0;
        data.mode = "timeattack";
        data.stageIndex = 0;
        data.stageClearTime = 0;

        InitializeConfiguration();
    }

    private void InitializeConfiguration()
    {
        if (GoogleSignIn.Configuration == null)
        {
            configuration = new GoogleSignInConfiguration
            {
                WebClientId = "449420461813-8plj91qr1jiksk1vft3090ogektutul3.apps.googleusercontent.com",
                RequestIdToken = true
            };
            GoogleSignIn.Configuration = configuration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GoogleSignIn.Configuration.RequestAuthCode = true;
            GoogleSignIn.Configuration.RequestEmail = true;
            GoogleSignIn.Configuration.RequestProfile = true;
        }
    }


    #region 구글로그인
    public void TryGoogleLogin()
    {
        
        saveStage = 0;

        if(GoogleSignIn.Configuration != null)
        GoogleSignIn.DefaultInstance.SignOut();

        /*
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        */

        InitializeConfiguration();

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
          OnAuthenticationFinished,TaskContinuationOptions.ExecuteSynchronously);
    }
    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            using (IEnumerator<System.Exception> enumerator =
                    task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error =
                            (GoogleSignIn.SignInException)enumerator.Current;

                    Debug.Log("구글 로그인 에러1");
                }
                else
                {
                    Debug.Log("구글 로그인 에러2");
                }
            }
        }
        else if (task.IsCanceled)
        {
            Debug.Log("요청이 취소됨");
        }
        else
        {
            Debug.Log("구글 로그인 성공!");

            userName.text = task.Result.DisplayName;
            Email = task.Result.Email;

            PlayerPrefs.SetString("name", task.Result.DisplayName);
            PlayerPrefs.SetString("email", task.Result.Email);
            PlayerPrefs.SetString("imageUrl", task.Result.ImageUrl.ToString());

            PlayerPrefs.Save();


            data.email = Email;
            data.name = task.Result.DisplayName;
            data.imageUrl = task.Result.ToString();
            imageUrl = task.Result.ToString();

            Task.Factory.StartNew(() => { Send(data); });


            //Debug.Log("Welcome: " + task.Result.DisplayName + task.Result.Email + "!");
            //TryFirebaseGoogleLogin(task);

            Firebase.Auth.Credential credential =
    Firebase.Auth.GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
            auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithCredentialAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                    return;
                }

                Firebase.Auth.FirebaseUser newUser = task.Result;

                Debug.Log("구글 파이어베이스 로그인 성공!");
                //Debug.Log(task.Result.DisplayName + newUser.Email + "11111111");

                


            });

        }
    }
    void TryFirebaseGoogleLogin(Task<GoogleSignInUser> task)
    {
        
        PlayerPrefs.DeleteAll();

        TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();

        Credential credential = GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
        auth.SignInWithCredentialAsync(credential).ContinueWith(authTask => {
            if (authTask.IsCanceled)
            {
                Debug.Log("구글 파이어베이스 취소됨");
                signInCompleted.SetCanceled();
            }
            else if (authTask.IsFaulted)
            {
                Debug.Log("구글 파이어베이스 폴트됨");
                signInCompleted.SetException(authTask.Exception);
            }
            else
            {
                Debug.Log("구글 파이어베이스 로그인 성공!");
                Debug.Log(signInCompleted.Task.Result.DisplayName + signInCompleted.Task.Result.Email + "11111111");
                Debug.Log(authTask.Result.DisplayName + authTask.Result.Email + "22222222");
                signInCompleted.SetResult(authTask.Result);

                userName.text = authTask.Result.DisplayName;
                Email = authTask.Result.Email;

                PlayerPrefs.SetString("name", authTask.Result.DisplayName);
                PlayerPrefs.SetString("email", authTask.Result.Email);
                PlayerPrefs.SetString("imageUrl", authTask.Result.PhotoUrl.ToString());

                PlayerPrefs.Save();


                data.email = Email;
                data.name = authTask.Result.DisplayName;
                data.imageUrl = authTask.Result.PhotoUrl.ToString();
                imageUrl = authTask.Result.PhotoUrl.ToString();

                Task.Factory.StartNew(() => { Send(data); });

            }
        });

    }
#endregion
    #region 애플로그인
    public void TryAppleLogin()
    {
        saveStage = 0;
        var siwa = gameObject.GetComponent<SignInWithApple>();
        siwa.Login();
    }

    public void CredentialButton()
    {
        // User id that was obtained from the user signed into your app for the first time.
        var siwa = gameObject.GetComponent<SignInWithApple>();
        siwa.GetCredentialState(userId);
    }

    public void OnCredentialState(SignInWithApple.CallbackArgs args)
    {
        Debug.Log(string.Format("User credential state is: {0}", args.credentialState));

        if (args.error != null)
            Debug.Log(string.Format("Errors occurred: {0}", args.error));
    }

    public void OnLogin(SignInWithApple.CallbackArgs args)
    {
        Debug.Log("Sign in with Apple login has completed.");

        UserInfo userInfo = args.userInfo;
        
        // Save the userId so we can use it later for other operations.
        userId = userInfo.userId;
        
        // Print out information about the user who logged in.
        Debug.Log(
            string.Format("Display Name: {0}\nEmail: {1}\nUser ID: {2}\nID Token: {3}", userInfo.displayName,
                userInfo.email, userInfo.userId, userInfo.idToken));
        userIdToken = userInfo.idToken;
        appleName = userInfo.displayName;
        TryFirebaseAppleLogin();

    }

    private void TryFirebaseAppleLogin()
    {
        
        Firebase.Auth.Credential credential =
    Firebase.Auth.OAuthProvider.GetCredential("apple.com", userIdToken, Guid.NewGuid().ToString(), null);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }



            Firebase.Auth.FirebaseUser newUser = task.Result;

            if (appleName != "")
            {
                Email = newUser.Email;
                userName.text = appleName;
                data.email = newUser.Email;
                data.name = appleName;

                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
                {
                    DisplayName = appleName,
                };
                newUser.UpdateUserProfileAsync(profile).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("UpdateUserProfileAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Debug.Log("User profile updated successfully.");

                    PlayerPrefs.SetString("name", newUser.DisplayName);
                    PlayerPrefs.SetString("email", newUser.Email);
                    PlayerPrefs.SetString("imageUrl", "null");
                    PlayerPrefs.Save();

                });




            }
            else
            {
                Email = newUser.Email;
                userName.text = newUser.DisplayName;
                data.email = newUser.Email;
                data.name = newUser.DisplayName;
                PlayerPrefs.SetString("name", newUser.DisplayName);
                PlayerPrefs.SetString("email", newUser.Email);
                PlayerPrefs.SetString("imageUrl", "null");
                PlayerPrefs.Save();
            }
                Debug.LogFormat("성공이냐: {0} \n ({1})",
                newUser.Email,newUser.DisplayName);

            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            
            

            PlayerPrefs.Save();
            Task.Factory.StartNew(() => { Send(data); });

        });

       

        
        

        

    }

        public void OnError(SignInWithApple.CallbackArgs args)
    {
        Debug.Log(string.Format("A Sign in with Apple error has occured! {0}", args.error));
    }


#endregion
    #region 카카오로그인
    // API 키
    public const string KakaoRestApiKey = "54cfbdb8950286ccb0896859f2b19de3";
    public const string KakaoSendMessageKey = "48038";

    // 리다이렉트 url
    public const string KakaoRedirectUrl = "https://www.naver.com/oauth";

    // 로그인 url
    public const string KakaoLogInUrl = "https://kauth.kakao.com/oauth/authorize?client_id=" + KakaoRestApiKey + "&redirect_uri=" + KakaoRedirectUrl + "&response_type=code";

    // 루트 url
    public const string KakaoHostOAuthUrl = "https://kauth.kakao.com";
    public const string KakaoHostApiUrl = "https://kapi.kakao.com";

    // 이벤트 url
    public const string KakaoOAuthUrl = "/oauth/token"; // AccessToken
    public const string KakaoUnlinkUrl = "/v1/user/unlink"; // LogOut
    public const string KakaoTemplateMessageUrl = "/v2/api/talk/memo/send"; // Template 메시지
    public const string KakaoDefaultMessageUrl = "/v2/api/talk/memo/default/send"; // Default 메시지
    public const string KakaoUserDataUrl = "/v2/user/me"; // 사용자 데이터


    // 유저 데이터
    public static string userToken; // 유저 토큰
    public static string accessToken; // 에셋 토큰
    public static string UserNickName; // 사용자 이름
    //public static Bitmap UserImg; // 사용자 이미지

    WebViewObject webViewObject;
    string currentUrl;
    bool finding = false;

    public void TryKakaoLogin()
    {

        finding = true;
        string strUrl = KakaoLogInUrl;

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            ld:(msg) => {
            //Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
            currentUrl = UnityWebRequest.UnEscapeURL(msg);
            //currentUrl = UnityWebRequest.UnEscapeURL(msg);
            GetUserToKen();
        },
        enableWKWebView: true);

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(0, 0, 0, 0);
    }

    public void GetUserToKen()
    {

        string wUrl = currentUrl;
        string newUserToken = wUrl.Substring(wUrl.IndexOf("=") + 1);

        Debug.Log("유저토큰 얻기");
        if (wUrl.CompareTo(KakaoRedirectUrl + "?code=" + newUserToken) == 0)
        {
            Debug.Log("유저 토큰 얻기 성공");
            userToken = newUserToken;
            finding = false;
            GetAccessToKen();
        }    
    }

    public void GetAccessToKen()
    {
        string[] data = new string[4];
        data[0] = "authorization_code";
        data[1] = KakaoRestApiKey;
        data[2] = KakaoRedirectUrl;
        data[3] = userToken;

        string postData = string.Format("grant_type={0}&client_id={1}&redirect_uri={2}&code={3}", data[0], data[1], data[2], data[3]);

        Debug.Log(postData);

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(KakaoHostOAuthUrl + KakaoOAuthUrl);
        // 인코딩 UTF-8
        byte[] sendData = UTF8Encoding.UTF8.GetBytes(postData);
        httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentLength = sendData.Length;
        Stream requestStream = httpWebRequest.GetRequestStream();
        requestStream.Write(sendData, 0, sendData.Length);
        requestStream.Close();
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
        string A = streamReader.ReadToEnd();
        streamReader.Close();
        httpWebResponse.Close();

        Debug.Log("return: " + A);

        JsonData userData = JsonMapper.ToObject(A);

        JsonData userTokenn = userData["access_token"];
        accessToken = userTokenn.ToString();

        StartCoroutine(KakaoUserData());
        //Debug.Log("어세스토큰 발급돼라 제발 좀" + accessToken);

    }

    public IEnumerator KakaoUserData()
    {

        UnityWebRequest www = UnityWebRequest.Get(KakaoHostApiUrl + KakaoUserDataUrl);
        www.SetRequestHeader("Authorization", "Bearer " + accessToken);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            //Debug.LogError(www.error);
            StartCoroutine(KakaoUserData());
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            JsonData userData = JsonMapper.ToObject(www.downloadHandler.text);


            JsonData userProperties = userData["properties"];
            JsonData userAccount = userData["kakao_account"];
            JsonData userEmail = userAccount["email"];
            JsonData nickName = userProperties["nickname"];
            JsonData image = userProperties["profile_image"];



            userName.text = nickName.ToString();
            Email = userEmail.ToString();
            imageUrl = image.ToString();

            PlayerPrefs.SetString("name", nickName.ToString());
            PlayerPrefs.SetString("email", userEmail.ToString());
            PlayerPrefs.SetString("imageUrl", image.ToString());

            PlayerPrefs.Save();


            data.email = userEmail.ToString();
            data.name = nickName.ToString();
            data.imageUrl = image.ToString();

            Debug.Log(data.email);
            Debug.Log(data.name);
            Debug.Log(data.imageUrl);


            Task.Factory.StartNew(() => { Send(data); });


            
            close();
        }

        

    }
    public void close()
    {

        var g = GameObject.Find("WebViewObject");
        if (g != null)
        {
            finding = false;
            webViewObject.ClearCookies();
            currentUrl = null;
            Destroy(g);
        }
    }
    #endregion
#endif
    private void Send(SendData data)
    {
        Debug.Log("보냄");
        
        //보낼 데이터
        // string,byte[]로 변환
        string str = JsonUtility.ToJson(data);
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        //주소와 세팅
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = bytes.Length;

        //stream 형식으로 데이터 보내기
        using (var stream = request.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Close();
        }

        //데이터를 StreamReader로 받음
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Debug.Log(json);
        if (json != "\"Sucess\"")
            Task.Factory.StartNew(() => { Send(data); });
        //string 값을 JsonUtility로 커스텀 클래스
        //yield return null;
    }

}
