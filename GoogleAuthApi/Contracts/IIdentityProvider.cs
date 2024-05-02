namespace GoogleAuthApi.Contracts
{
    public interface IIdentityProvider
    {
        public Task<string> ValidateGoogleToken(string idToken);
    }
}
