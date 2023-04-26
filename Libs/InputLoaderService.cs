namespace Libs {
    public class InputLoaderService {
        private readonly IHttpClientFactory _httpClientFactory = null!;

        public InputLoaderService(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetInputAsync(int year, int day) {
            using HttpClient client = _httpClientFactory.CreateClient();
            try {
                return await client.GetStringAsync($"{year}/day/{day}/input");
            } catch (Exception ex) {
                Console.WriteLine("Error getting something fun to say: {Error}", ex);
            }

            return "";
        }
    }
}