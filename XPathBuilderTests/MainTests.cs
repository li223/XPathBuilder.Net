using XPathBuilder.Net;
using XPathBuilder.Net.Objects;

namespace XPathBuilderTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod("Build simple pane")]
        public void BuildSimplePane()
        {
            var builder = new PathBuilder();
            builder.HasComponent(PathComponentType.Pane, pane =>
            {
                pane.WithParameter("ClassName", "TestClassName");
            });

            Assert.AreEqual(@"/Pane[@ClassName=""TestClassName""]", builder.ToString());
        }

        [TestMethod("Test internal withs")]
        public void TestInternalWiths()
        {
            var builder = new PathBuilder();
            builder.HasComponent(PathComponentType.Window, window =>
            {
                window.WithName("TestWindow");
                window.WithClassName("TestClass");
            });

            Assert.AreEqual(@"/Window[@Name=""TestWindow""][@ClassName=""TestClass""]", builder.ToString());
        }

        [TestMethod("Test multi-components")]
        public void TestMultiComponents()
        {
            var builder = new PathBuilder();
            builder
                .HasComponent(PathComponentType.Window, _ => { })
                .HasComponent(PathComponentType.Pane, _ => { });

            Assert.AreEqual(@"/Window/Pane", builder.ToString());
        }

        [TestMethod("Test having a root")]
        public void TestHavingRoot()
        {
            var builder = new PathBuilder();
            builder.HasRoot(rootBuilder =>
            {
                rootBuilder.HasComponent(PathComponentType.Window, _ => { });
            });

            Assert.AreEqual("/Window", builder.ToString());
        }
    }
}