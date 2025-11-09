namespace GameLibrary.Frontend.Services
{
    public interface IGameService
    {
        Task<T> GetAsync<T>(string url);

        Task<T> GetByIdAsync<T>(string url, string SKU);

        Task<HttpResponseMessage> PostAsync<T>(string url, T model);
    }
}
