using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using LoginResult = PlayFab.ClientModels.LoginResult;
using PlayFabError = PlayFab.PlayFabError;
public class LoginRegister : MonoBehaviour
{
    public TextMeshProUGUI messagetext;
    public TextMeshProUGUI emailField;
    public TextMeshProUGUI passwordField;
    public TextMeshProUGUI usernameField;
    private string _playFabPlayerIdCache;

    public void RegisterButton()
    {
        if (passwordField.text.Length < 6)
        {
            messagetext.text = "Password too short !";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            //Username = usernameField.text,
            Email = emailField.text,
            Password = passwordField.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterSucces,OnError);
    }

    void OnRegisterSucces(RegisterPlayFabUserResult result)
    {
        messagetext.text = "Status : Registered !";
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Position", "0/0"},
                {"Money", "100"},
                {"MaxHp", "20"},
                {"Hp", "20"},
                {"MaxMana", "100"},
                {"Mana", "100"},
                {"Level", "1"},
                {"Speed","30"},
                {"Xp","0"}
            }
        };
        PlayFabClientAPI.UpdateUserData(request,OnDataSend,OnError);
        LoginButton();
    }

    void OnDataSend(UpdateUserDataResult result)
    {
    }

    void OnError(PlayFabError result)
    {
        messagetext.text = "Status : " + result.ErrorMessage;
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailField.text,
            Password = passwordField.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request,RequestPhotonToken,OnError);
    }

    void RequestPhotonToken(LoginResult result)
    {
        
        messagetext.text = "Status : PlayFab authenticated. Requesting photon token...";
        _playFabPlayerIdCache = result.PlayFabId;
        PlayFabClientAPI.GetPhotonAuthenticationToken(new GetPhotonAuthenticationTokenRequest
        {
            PhotonApplicationId = "6f6b8d03-de23-4c5d-9099-de2e8f63fda7"
        }, AuthenticateWithPhoton, OnError);
    }

    void AuthenticateWithPhoton(GetPhotonAuthenticationTokenResult result)
    {
        messagetext.text = "Status : Photon token acquired! Authentication complete.";

        //We set AuthType to custom, meaning we bring our own, PlayFab authentication procedure.
        var customAuth = new AuthenticationValues { AuthType = CustomAuthenticationType.Custom };
        //We add "username" parameter. Do not let it confuse you: PlayFab is expecting this parameter to contain player PlayFab ID (!) and not username.
        customAuth.AddAuthParameter("username", _playFabPlayerIdCache);    // expected by PlayFab custom auth service

        //We add "token" parameter. PlayFab expects it to contain Photon Authentication Token issues to your during previous step.
        customAuth.AddAuthParameter("token", result.PhotonCustomAuthenticationToken);

        //We finally tell Photon to use this authentication parameters throughout the entire application.
        PhotonNetwork.AuthValues = customAuth;

        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }

    public void ResetPassword()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailField.text,
            TitleId = "B1CBC"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,OnPasswordReset,OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messagetext.text = "Status : Recovery email sent !";
    }
    
}
