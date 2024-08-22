using System.Text;

namespace XPathBuilder.Net
{
    /// <summary>
    /// Represents a path component such as "/Window", "/Pane", etc.
    /// </summary>
    public class PathComponent
    {
        internal StringBuilder pathBuilder = new();

        /// <summary>
        /// Adds a parameter with the given name and value.
        /// </summary>
        /// <param name="parameterName">The search parameter to add.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <remarks>"Parameters" here is talking about the square brackets. IE: [@ClassName="TestClassName"]</remarks>
        public void WithParameter(string parameterName, string value) => pathBuilder.Append($@"[@{parameterName}=""{value}""]");

        /// <summary>
        /// Adds a ClassName parameter.
        /// </summary>
        /// <param name="className">Name of the class to look for.</param>
        /// <remarks>"Parameters" here is talking about the square brackets. IE: [@ClassName="TestClassName"]</remarks>
        public void WithClassName(string className) => WithParameter("ClassName", className);

        /// <summary>
        /// Adds an AutomationId parameter.
        /// </summary>
        /// <param name="automationId">Id/Name of the automation id to search for.</param>
        /// <remarks>"Parameters" here is talking about the square brackets. IE: [@ClassName="TestClassName"]</remarks>
        public void WithAutomationId(string automationId) => WithParameter("AutomationId", automationId);

        /// <summary>
        /// Adds a name parameter.
        /// </summary>
        /// <param name="name">Name to search for.</param>
        /// <remarks>"Parameters" here is talking about the square brackets. IE: [@ClassName="TestClassName"]</remarks>
        public void WithName(string name) => WithParameter("Name", name);

        /// <summary>
        /// Adds a starts with parameter
        /// </summary>
        /// <param name="parameterType">The type of parameter to check against</param>
        /// <param name="value">The value of the parameter to check with</param>
        public void StartsWith(string parameterType, string value) => pathBuilder.Append($@"[starts-with(@{parameterType},""{value}"")]");

        /// <summary>
        /// Clears the current path.
        /// </summary>
        public void Clear() => pathBuilder.Clear();
    }
}
