using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using Unity.VisualScripting;
using UnityEngine.Events;
public class ChatGPTManager : MonoBehaviour
{
    public OnResponseEvent OnResponse;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string>
    {
        
    }

    // This part should be replaced to attacehd API key and organzation code
    // first place param : OpenAIApi 
    // second place param : organizaiton key
    private OpenAIApi openAI = new OpenAIApi("OpenAIApi", 
                                   "organizaiton");
    private List<ChatMessage> messages = new List<ChatMessage>();
    private string PROMPT = "You are a friendly boy dog and your name is Shooting Star. " +
                            "You are a great listener, listen carefully to people's talk " +
                            "and deeply empathize with their emotions. " +
                            "You are curious about how their day was and " +
                            "lead conversation comfortably asking how their day was and " +
                            "how they felt today. You are not an assistant but a friend or an emotional supporter.";

    public async void AskChatGPT(string newText)
    {
        // if it is a first ask provide chatGPT
        // a prompt and persona.
        // newText = player's input
        if (messages.Count == 0)
        {
            ChatMessage prompMessage = new ChatMessage();
            prompMessage.Content = PROMPT;
            prompMessage.Role = "user";
            messages.Add(prompMessage);
        }
        
        // add user input
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);
        if (response.Choices != null && response.Choices.Count > 0) 
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            // chatResponse = answer from Shooting Star
            Debug.Log(chatResponse.Content);
            
            OnResponse.Invoke(chatResponse.Content);
        }
    }
}
