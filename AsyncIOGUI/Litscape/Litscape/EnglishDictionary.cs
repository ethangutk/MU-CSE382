using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Litscape {
    public class EnglishDictionary {
        Task task = null;
        HashSet<string> dictionary;

        public EnglishDictionary(StreamReader reader) {
            dictionary = new HashSet<string>();
            task = LoadDictionary(reader);
        }
        private async Task LoadDictionary(StreamReader reader) {
            while (!reader.EndOfStream) {
                string line = await reader.ReadLineAsync().ConfigureAwait(false);
                dictionary.Add(line.ToUpper());
            }
            await Task.Delay(5000).ConfigureAwait(false);
        }

        public static int cnt = 0;
        public bool IsLegal(string word) {
            Debug.WriteLine(task.Status + " " + cnt++);
            if (task != null && !task.IsCompleted) {
                Debug.WriteLine("Need to wait");
                task.Wait();
            }
            return dictionary.Contains(word.ToUpper());
        }
    }
}

