public class WebSocketExample : UnityEngine.MonoBehaviour
{
    private WebSocket4Net.WebSocket _client;

    private void Start()
    {
        _client = new WebSocket4Net.WebSocket("ws://irc-ws.chat.twitch.tv:80");
        _client.Opened += (sender, e) => UnityEngine.Debug.Log("Opened");
        _client.Open();
    }

    private void OnDestroy() => _client.Dispose();

    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CreateSingletonInstance() => new UnityEngine.GameObject().AddComponent<WebSocketExample>();
}