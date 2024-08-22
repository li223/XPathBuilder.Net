namespace XPathBuilder.Net
{
    public partial class PathBuilder
    {
        /// <summary>
        /// Adds a window component
        /// </summary>
        /// <param name="action">The builder action to perform</param>
        public PathBuilder HasWindow(Action<PathComponent> action) => this.HasComponent(Objects.PathComponentType.Window, action);

        /// <summary>
        /// Adds a window component
        /// </summary>
        public PathBuilder HasWindow() => this.HasComponent(Objects.PathComponentType.Window);

        /// <summary>
        /// Adds a pane component
        /// </summary>
        /// <param name="action">The builder action to perform</param>
        public PathBuilder HasPane(Action<PathComponent> action) => this.HasComponent(Objects.PathComponentType.Pane, action);

        /// <summary>
        /// Adds a pane component
        /// </summary>
        public PathBuilder HasPane() => this.HasComponent(Objects.PathComponentType.Pane);

        /// <summary>
        /// Adds a button component
        /// </summary>
        /// <param name="action">The builder action to perform</param>
        public PathBuilder HasButton(Action<PathComponent> action) => this.HasComponent(Objects.PathComponentType.Button, action);

        /// <summary>
        /// Adds a button component
        /// </summary>
        public PathBuilder HasButton() => this.HasComponent(Objects.PathComponentType.Pane);
    }
}
