
using VContainer.Unity;

namespace vContainerDemo
{
    public class GamePresenter : IStartable
    {
        private readonly HelloScreen _helloScreen;
        private readonly HelloWorldService _helloWorldService;

        public GamePresenter(HelloScreen helloScreen, HelloWorldService helloWorldService)
        {
            _helloScreen = helloScreen;
            _helloWorldService = helloWorldService;
        }

        public void Start()
        {
            _helloScreen.HelloButton.onClick.AddListener((() => _helloWorldService.Hello()));
        }
    }
}
