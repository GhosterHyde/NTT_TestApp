using System.Collections;

namespace NTT_TestApp.Interfaces
{
    internal interface IGui
    {
        public void Clear();
        public void StartLoading();
        public void StopLoading();
        public void ShowProducts(IEnumerable Items);
        public void ShowCategories(IEnumerable Items);
    }
}
