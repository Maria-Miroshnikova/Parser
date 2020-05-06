// Template generated code from Antlr4BuildTasks.Template v 2.1
namespace myLovelyProject
{
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime;
    using System;

    public class Program
    {
        static void Try(string input)
        {
            var str = new AntlrInputStream(input);
            var lexer = new arithmeticLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new arithmeticParser(tokens);

            var listener = new ErrorListener<IToken>(parser, lexer, tokens);
            
            parser.AddErrorListener(listener);

            arithmeticParser.FileContext tree;

            try
            {
                tree = parser.file(); // строит дерево

                System.Console.WriteLine("parse completed.");
                System.Console.WriteLine(tokens.OutputTokens());
                System.Console.WriteLine(tree.OutputTree(tokens));
                var visitor = new ParsingTreeVisitor();
                visitor.Visit(tree); // обходит правильное дерево, вычисляя результат
            }
            catch (ParseCanceledException error)
            {
                System.Console.WriteLine("error in parse.");
                System.Console.WriteLine(error.Message);
            }
        }

        static void Main(string[] args)
        {
            Try("1 + 2");
            Try("1 2");
        }
    }
}
