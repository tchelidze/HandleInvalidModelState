using System;

namespace HandleInvalidModelState.Exceptions
{
    public class InvalidViewModelInitializerTypeException : Exception
    {
        public InvalidViewModelInitializerTypeException(Type invalidViewModelInitializerType)
            => InvalidViewModelInitializerType = invalidViewModelInitializerType;

        public Type InvalidViewModelInitializerType { get; }
    }
}