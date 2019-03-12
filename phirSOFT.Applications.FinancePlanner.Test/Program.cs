using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phirSOFT.Test.Finanzplan.DB;
using static phirSOFT.Common.ConsoleTools;
namespace phirSOFT.Test.Finanzplan
{
    class Program
    {
        static AppDbContext _db;

        static void Main(string[] args)
        {
            PromtPhirsoft();
            WriteColor("Connecting to database...", ConsoleColor.DarkGreen);
            _db = new AppDbContext();

            //Menu Loop
            while (true)
            {
                switch (ShowMenu())
                {
                    case Menumode.Categories:
                        HandleCategories();
                        break;
                    case Menumode.Exit:
                        return;
                }
            }

        }

        private static Menumode ShowMenu()
        {
            WriteInNewLine("Mainmenu:");
            WriteInNewLine("1. Categories");
            WriteInNewLine("2. Exit");
            return (Menumode)GetNumber("Choice:", 1, 2);
        }

        private static void HandleCategories()
        {
            while (true)
            {
                var query = from c in _db.Categories
                            where c.Parent == null
                            orderby c.Title
                            select c;
                var s = new Stack<Category>();

                foreach (var c in query)
                    WriteNode(c);
                Category node = null;

                while (node == null)
                {
                    var id = GetNumber("Kategorie auswählen:");
                    node = (from c in _db.Categories where c.Id == id select c).First();
                }

                Console.WriteLine($"[{(node.System ? "x" : " ")}] {node.Title} ({node.Signum}) [{node.Id}]");

                switch (ShowCategoriesMenu())
                {
                    case ItemEditmode.Add:
                        var name = (string)Promt("Name eingeben");
                        var no = new Category();
                        no.Parent = node;
                        no.Title = name;
                        no.Signum = node.Signum;
                        _db.Categories.Add(no);
                        _db.SaveChanges();
                        break;

                    case ItemEditmode.Delete:
                        _db.Categories.Remove(node);
                        _db.SaveChanges();
                        break;
                    case ItemEditmode.Edit:
                        var newname = (string)Promt("Name eingeben");
                        node.Title = newname;
                        _db.SaveChanges();
                        break;
                    case ItemEditmode.Back:
                        return;
                }
            }

        }

        private static ItemEditmode ShowCategoriesMenu()
        {
            WriteInNewLine("Node Action");
            WriteInNewLine("1. Delete");
            WriteInNewLine("2. Edit");
            WriteInNewLine("3. Add new child");
            WriteInNewLine("4. Return to Mainmenu");
            return (ItemEditmode)GetNumber("Choice:", 1, 4);
        }

        private enum ItemEditmode
        {
            Add = 3,
            Edit = 2,
            Delete = 1,
            Back = 4,
        }

        private enum Menumode
        {
            Exit = 2,
            Categories = 1
        }

        private static string _indent = "";

        private static void WriteNode(Category c)
        {
            Console.WriteLine($"{_indent}{c.Title} ({c.Signum}) [{c.Id}]");
           
            _indent += " ";
            if (c.SubCategories!=null)
            foreach (var node in c.SubCategories)
            {
                WriteNode(node);
            }
            _indent = _indent.Substring(1);
        }
    }
}
