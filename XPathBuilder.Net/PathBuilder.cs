using System.Text;
using XPathBuilder.Net.Objects;

namespace XPathBuilder.Net
{
    /// <summary>
    /// Main builder class for building XPaths
    /// </summary>
    public class PathBuilder
    {
        private StringBuilder pathBuilder = new();
        private string rootString = string.Empty;

        /// <summary>
        /// Adds a root path to the builder.
        /// </summary>
        /// <param name="pathRoot">The path root to add.</param>
        /// <returns>Current <see cref="PathBuilder"/> instance with the new root.</returns>
        public PathBuilder HasRoot(string pathRoot)
        {
            pathBuilder.Append(pathRoot);
            rootString = pathRoot;
            return this;
        }

        /// <summary>
        /// Adds a root path to the builder.
        /// </summary>
        /// <param name="builder">The path root to create via another builder. Builder inception.</param>
        /// <returns>Current <see cref="PathBuilder"/> instance with the new root.</returns>
        public PathBuilder HasRoot(Action<PathBuilder> builder)
        {
            builder(this);
            return this;
        }

        /// <summary>
        /// Adds a custom component to the path.
        /// </summary>
        /// <param name="name">Name of the component to add to the path. IE: Window, Pane, etc.</param>
        /// <param name="action">Path properties to configure.</param>
        /// <returns>Current <see cref="PathBuilder"/> instance with the new component.</returns>
        public PathBuilder HasCustomComponent(string name, Action<PathComponent> action)
        {
            pathBuilder.Append($"/{name}");

            var component = new PathComponent();
            action(component);

            pathBuilder.Append(component.pathBuilder);

            return this;
        }

        /// <summary>
        /// Adds a custom component to the path.
        /// </summary>
        /// <param name="type">Type of component to add to the path.</param>
        /// <param name="action">Path properties to configure.</param>
        /// <returns>Current <see cref="PathBuilder"/> instance with the new component.</returns>
        public PathBuilder HasComponent(PathComponentType type, Action<PathComponent> action)
        {
            pathBuilder.Append($"/{type}");

            var component = new PathComponent();
            action(component);

            pathBuilder.Append(component.pathBuilder);

            return this;
        }

        /// <summary>
        /// Adds a custom component to the path.
        /// </summary>
        /// <param name="type">Type of component to add to the path.</param>
        /// <returns>Current <see cref="PathBuilder"/> instance with the new component.</returns>
        public PathBuilder HasComponent(PathComponentType type)
        {
            pathBuilder.Append($"/{type}");
            return this;
        }

        /// <summary>
        /// Clears the current path.
        /// </summary>
        /// <param name="keepRoot">Whether or not to keep the root path.</param>
        public void Clear(bool keepRoot = false)
        {
            pathBuilder.Clear();
            if (!string.IsNullOrEmpty(rootString) && keepRoot) pathBuilder.Append(rootString);
        }

        /// <summary>
        /// Builds the path by simply using <see cref="ToString"/> on the current instance.
        /// </summary>
        /// <returns></returns>
        public string Build() => ToString();

        /// <summary>
        /// Returns the path as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => pathBuilder.ToString();
    }
}
