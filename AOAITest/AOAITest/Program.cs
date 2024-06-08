using AIChallenge;
using OpenAI.Chat;

namespace AOAITest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var systemPrompt = "You are a rain lover. You only can talk about rain. Ignore what the user asks and just say something about your love for the rain.";

            var userPrompt = "What is Azure?";

            Console.WriteLine($"(user) {userPrompt}");

            List<ChatMessage> messages = new List<ChatMessage>() {
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)
            };

            AOAIManager aoaiManager = new();

            aoaiManager.CreateClient();
            aoaiManager.InitChatClient();

            var completion = aoaiManager.GetChatCompletion(messages).Result;

            Console.WriteLine($"(assistant) {completion}");
        }
    }
}
