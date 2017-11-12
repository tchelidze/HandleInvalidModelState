namespace HandleInvalidModelState.ActionFilters
{
    public interface IViewModelInitializer
    {
        object Initialize(object viewModel);
    }
}