# HuggingFace .NET Client

A powerful and developer-friendly .NET client for accessing Hugging Face models with ease. This NuGet package supports four core tasks:

- Chat Completions (sync and streaming)
- Feature Extraction
- Text-to-Image Generation

---

## 📦 Installation

Install via NuGet:

```bash
dotnet add package HuggingFaceClient --version 1.0.x
```

---

## 🚀 Getting Started

Initialize the Hugging Face client by providing your API token and the endpoint URL:

```csharp
var hfClient = new HfClient("hf_your_token_here", "https://your-endpoint-url");
```

---

## 💬 Chat Completions

### Synchronous Response

```csharp
var hfClient = new HfClient("hf_xxxxxxxxxxxxxx",
    "https://router.huggingface.co/together/v1/chat/completions");

var message = hfClient.Chat
    .WithModel("Qwen/Qwen2.5-Coder-32B-Instruct")
    .AddUserMessage("Hello, how is your day?")
    .SendAsync();

Console.WriteLine(message.Result?.Choices[0].Message);
```

### Streaming Response

```csharp
var hfClient = new HfClient("hf_xxxxxx",
    "https://router.huggingface.co/together/v1/chat/completions");

var messages = hfClient.Chat
    .WithModel("Qwen/Qwen2.5-Coder-32B-Instruct")
    .AddUserMessage("Hello, how is your day?")
    .SendStreamAsync();

foreach (var message in messages.Result) {
    Console.WriteLine(message.Choices[0].Delta.Content);
}
```

---

## 🧠 Feature Extraction

```csharp
var hfClient = new HfClient("hf_xxxxxx",
    "https://router.huggingface.co/hf-inference/pipeline/feature-extraction/intfloat/multilingual-e5-large-instruct");

var features = hfClient.ExtractFeatures
    .WithInputs("Hello, World.")
    .SendAsync();

foreach (var feature in features.Result?.Features)
{
    Console.WriteLine(feature);
}
```

---

## 🎨 Text-to-Image Generation

```csharp
var hfClient = new HfClient("hf_xxxxxxxxxxxxxxxxxxxx",
    "https://router.huggingface.co/replicate/v1/models/black-forest-labs/flux-dev/predictions");

var message = hfClient.TextToImage
    .WithPrompt("Generate an image of a cat riding a bike.")
    .SendAsync();

Console.WriteLine(message.Result?.Data[0].Url);
```

---

## 📄 License

This project is licensed under the MIT License.

---

## 🤝 Contributing

Contributions, suggestions, and feature requests are welcome! Feel free to open an issue or submit a pull request.

---

## 🔗 Links

- **NuGet Package:** https://www.nuget.org/packages/HuggingFace.Client
- **GitHub Repository:** https://github.com/yourusername/HuggingFace.Client
- **Hugging Face Docs:** https://huggingface.co/docs

