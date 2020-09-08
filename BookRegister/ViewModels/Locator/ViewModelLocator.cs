using BookRegister.Services;
using Unity;

namespace BookRegister.ViewModels.Locator
{
    class ViewModelLocator
    {
        private IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();
            _container.RegisterType<IFileService, JsonFileService>(TypeLifetime.Singleton);
            _container.RegisterType<IBookService, BookService>(TypeLifetime.Singleton);
        }

        public MainViewModel MainViewModel
        {
            get {
                IFileService fileService = _container.Resolve<IFileService>();
                IBookService bookService = _container.Resolve<IBookService>();
                return new MainViewModel(fileService, bookService);
            }
        }
    }
}
