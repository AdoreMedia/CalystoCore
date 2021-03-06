using System.Text;
using System.Threading.Tasks;

namespace Calysto.RazorGenerator.Mvc
{
    //https://github.com/RazorGenerator/RazorGenerator

    public class RazorTemplateBase
    {
        string _content;
        private readonly StringBuilder _generatingEnvironment = new StringBuilder();

        public RazorTemplateBase Layout { get; set; }

        public virtual void Execute() {}

        public void WriteLiteral(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
                return;
            _generatingEnvironment.Append(textToAppend); 
        }

        public virtual void Write(object value)
        {
            if (value == null)
                return;
            WriteLiteral(value.ToString());
        }

        public virtual object RenderBody()
        {
            return _content;
        }

        public virtual string TransformText()
        {
            Execute();
            
            if (Layout != null)
            {
                Layout._content = _generatingEnvironment.ToString();
                return Layout.TransformText();
            }

            return _generatingEnvironment.ToString();
        }

        public static HelperResult RenderPartial<T>() where T : RazorTemplateBase, new()
        {
            return new HelperResult(writer =>
            {
                var t = new T();
                writer.Write(t.TransformText());
            });
        }

        public virtual async Task ExecuteAsync()
        {
            await Task.Run(this.Execute);
        }
    }
}
