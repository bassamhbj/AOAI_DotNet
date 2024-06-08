using Azure;
using Azure.AI.OpenAI;
using OpenAI;
using OpenAI.Chat;

namespace AIChallenge
{
    internal class AOAIManager
    {
        private const string AOAI_ENDPOINT = "";
        private const string AOAI_API_KEY = "";

        private const string DEPLOYMENT_CHAT = "";

        public OpenAIClient Client { get; private set; }

        private ChatClient _chatClient { get; set; }

        public AOAIManager() { }

        public void CreateClient()
        {
            Client = new AzureOpenAIClient(
                new Uri(AOAI_ENDPOINT),
                new AzureKeyCredential(AOAI_API_KEY)
            );
        }

        public void InitChatClient()
        {
            _chatClient = Client.GetChatClient(DEPLOYMENT_CHAT);
        }

        public async Task<string> GetChatCompletion(List<ChatMessage> messages)
        {
            ChatCompletionOptions options = new()
            {
                Temperature = 0.7f
            };


            var response = await _chatClient.CompleteChatAsync(messages, options);

            var choice = response.Value.Content;

            return choice[0].Text;
        }
    }
}
