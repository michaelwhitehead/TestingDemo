using System;
using FreshMvvm;

namespace TestingDemo
{
    public class CustomPageMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName?
                .Replace(".ViewModels.", ".Views.")
                .Replace("ViewModel", "Page");
        }
    }
}
