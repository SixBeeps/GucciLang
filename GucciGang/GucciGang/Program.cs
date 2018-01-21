using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GucciLang {
    class Program {
        public static int variable;
        public static List<string> code = new List<string> { string.Empty };
        static void Main(string[] args) {
            if (args.Length != 0) { // Opened with a file
                FileStream fs = new FileStream(args[0], FileMode.Open);
                byte[] codeBytes = new byte[fs.Length];
                fs.Read(codeBytes, 0, (int)fs.Length);
                foreach(byte b in codeBytes) {
                    char c = Convert.ToChar(b);
                    if (c != '\n')
                        code[code.Count - 1] += c;
                    else
                        code.Add(string.Empty);
                }
                code[code.Count] += " ";
                Run(code);
            } else {
                Console.WriteLine("Please open this program using the \"Open With\" dialog");
            }
            while (true) {
                System.GC.Collect();
            }
        }

        protected static void Run(List<string> code) {
            foreach(string line in code) {
                int guccis = 0;
                for (int i = 0; i < line.Length - "gucci gang".Length; i++) {
                    if (line.Substring(i, "gucci gang".Length) == "gucci gang") {
                        guccis++;
                    }
                }
                switch (guccis) {
                    case 1:
                        variable++;
                        break;
                    case 2:
                        variable--;
                        break;
                    case 3:
                        Console.Write(Convert.ToChar(variable));
                        break;
                    case 4:
                        variable = Console.ReadKey().KeyChar;
                        break;
                    case 5:
                        if (variable != 0) {
                            break;
                        } else {
                            return;
                        }
                }
            }
        }
    }
}
