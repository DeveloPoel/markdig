using Markdig.Renderers.Normalize;
using Markdig.Syntax;
using NUnit.Framework;
using System.IO;

namespace Markdig.Tests
{
    internal static class TestRoundtrip
    {
        internal static void TestSpec(string markdownText, string expected, string extensions)
        {
            RoundTrip(markdownText);
        }

        internal static void RoundTrip(string markdown)
        {
            var pipelineBuilder = new MarkdownPipelineBuilder();
            MarkdownPipeline pipeline = pipelineBuilder.Build();
            MarkdownDocument markdownDocument = Markdown.Parse(markdown, pipeline);
            var sw = new StringWriter();
            var nr = new NormalizeRenderer(sw);

            nr.Write(markdownDocument);

            Assert.AreEqual(markdown, sw.ToString());
        }
    }
}
