namespace WordGame
{
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class ValidWords : IValidWords
    {
        ArrayList a = new ArrayList();
        // Maybe rename this member to hold more meaning - ex: _validWords;
        // Depending on coding rules/consistency add the access modifier: private readonly
        // I would use a List<string> here to clarify what are the types of objects being stored

        public ValidWords()
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                stream = Assembly.GetAssembly(typeof(ValidWords)).GetManifestResourceStream("WordGame.wordlist.txt");
                // if this line throws an exception (or the returned stream is null) then the finally clause will call the .Dispose() methods on null objects
                // consider a safer way to dispose of the objects with the using(...) statement

                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    a.Add(reader.ReadLine());
                }
            }
            finally
            {
                reader.Dispose();
                stream.Dispose();
                // Calling reader.Dispose() will dispose of the underlying stream, so it's not necessary to dispose of the stream after disposing the reader
            }
        }

        // I would remove this from the interface and thus the implementation here
        public int Size
        {
            get { return a.Count; }
        }

        public bool Contains(string word)
        {
            return a.Contains(word);
        }
    }
}
