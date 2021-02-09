using System.Collections.Generic;
using System.ComponentModel;

namespace CrtSetList.MyClasses
{
    public static class Extensions
    {
        // метод для конвертации из List  в BindingList
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> list)
        {
            var bindingList = new BindingList<T>();
            foreach (T item in list)
            {
                bindingList.Add(item);
            }
            return bindingList;
        }
    }
}
