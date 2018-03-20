using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Extended.Wpf.Behaviors.Utility
{
    public static class DependencyObjectExtractor
    {
        public static IEnumerable<DependencyObjectInfo> Extract()
        {
            return new Type[0]
                .Union(typeof(DependencyObject).Assembly.GetExportedTypes())
                .Union(typeof(Window).Assembly.GetExportedTypes())
                .Union(typeof(UIElement).Assembly.GetExportedTypes())
                .Where(x => x.IsSubclassOf(typeof(DependencyObject))
                            && !x.IsAbstract
                            && x.GetEvents().Any())
                .OrderBy(x => x.Namespace)
                .ThenBy(x => x.Name)
                .Select(x => new DependencyObjectInfo(x));
        }
    }

    public class DependencyObjectInfo
    {
        public DependencyObjectInfo(Type type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public Type Type { get; }

        public string Namespace => Type.Namespace?.Replace("System.Windows", "Extended.Wpf.Behaviors");

        public string TypeName => Type.Name + "Behavior";


        public override string ToString() => Type.FullName;
    }
}
