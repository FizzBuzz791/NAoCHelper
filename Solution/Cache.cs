using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace NAoCHelper
{
    public class Cache
    {
        private string CacheLocation { get; set; }
        private JsonSerializer Serializer { get; }

        public Cache()
        {
            var cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NAoCHelper");
            if (!Directory.Exists(cachePath))
                Directory.CreateDirectory(cachePath);
            CacheLocation = Path.Combine(cachePath, "PuzzleCache.json");

            Serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        }

        public string GetInput(int year, int day)
        {
            var input = string.Empty;

            if (!File.Exists(CacheLocation))
            {
                var fs = File.Create(CacheLocation);
                fs.Dispose();
            }

            using (StreamReader cacheFileStream = File.OpenText(CacheLocation))
            {
                PuzzleCache pc = null;
                // Only try to read if there's something to read. Might be better to use a try-catch around the Deserialize?
                if (!cacheFileStream.EndOfStream)
                {
                    pc = (PuzzleCache)Serializer.Deserialize(cacheFileStream, typeof(PuzzleCache));
                }

                if (pc != null)
                {
                    var targetPuzzle = pc.Puzzles.SingleOrDefault(p => p.Year == year && p.Day == day);
                    if (targetPuzzle != null)
                        input = targetPuzzle.Input;
                }
            }

            return input;
        }

        public bool SaveInput(Puzzle puzzle)
        {
            bool cachedSuccessfully = false;

            PuzzleCache pc = null;

            using (StreamReader cacheFileStream = File.OpenText(CacheLocation))
            {
                // Only try to read if there's something to read. Might be better to use a try-catch around the Deserialize?
                if (!cacheFileStream.EndOfStream)
                {
                    pc = (PuzzleCache)Serializer.Deserialize(cacheFileStream, typeof(PuzzleCache));
                }

                if (pc == null)
                {
                    // No cache, create a new one.
                    pc = new PuzzleCache();
                    pc.Puzzles.Add(puzzle);
                }
                else
                {
                    var targetPuzzle = pc.Puzzles.SingleOrDefault(p => p.Year == puzzle.Year && p.Day == puzzle.Day);
                    if (targetPuzzle != null)
                    {
                        // Already cached, update it by giving it the input puzzle.
                        pc.Puzzles.Remove(targetPuzzle);
                        pc.Puzzles.Add(puzzle);
                    }
                    else
                    {
                        // Cache exists, but this puzzle isn't there yet.
                        pc.Puzzles.Add(puzzle);
                    }
                }
            }

            // Write the updated cache back to file.
            using (StreamWriter cacheFileStream = File.CreateText(CacheLocation))
            {
                Serializer.Serialize(cacheFileStream, pc);
                cachedSuccessfully = true;
            }

            return cachedSuccessfully;
        }
    }
}