using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      RunTeleprompter().Wait();
    }

    private static async Task RunTeleprompter()
    {
        var config = new TelePrompterConfig();
        var displayTask = ShowTeleprompter(config);

        var speedTask = GetInput(config);
        // creates a Task that finishes as soon as any of the tasks in its argument
        // list completes
        await Task.WhenAny(displayTask, speedTask);
    }

    private static async Task ShowTeleprompter(TelePrompterConfig config)
    {
      var words = ReadFrom("sampleQuotes.txt");

      foreach (var word in words)
      {
        Console.Write(word);

        // if the current word is NOT null or whitespace...
        if (!string.IsNullOrWhiteSpace(word))
        {
          await Task.Delay(config.DelayInMilliseconds);
        }
      }

      config.SetDone();
    }

    private static async Task GetInput(TelePrompterConfig config)
    {
      Action work = () =>
      {
        do
        {
          var key = Console.ReadKey(true);

          if (key.KeyChar == '>')
          {
            config.UpdateDelay(-10);
          }
          else if (key.KeyChar == '<')
          {
            config.UpdateDelay(10);
          }
          else if (key.KeyChar == 'X' || key.KeyChar == 'x')
          {
            config.SetDone();
          }
        } while (!config.Done);
      };

      await Task.Run(work);
    }

    // this is called an Iterator method
    // Enumerator methods return sequences that are evaluated lazily.
    static IEnumerable<string> ReadFrom(string file)
    {
      string line;

      // reader receives StreamReader object from the .OpenText(String) method
      using (var reader = File.OpenText(file))
      {

        while ((line = reader.ReadLine()) != null)
        {
          var words = line.Split(' ');
          var lineLength = 0;

          foreach (var word in words)
          {
            yield return word + " ";
            lineLength += word.Length + 1;

            // change this value to adjust the length of each outputted line when using Write(line) in the main method
            // OR to break chunks of text up into smaller or bigger pieces when using WriteLine(line) in the main method
            if (lineLength > 70)
            {
              yield return Environment.NewLine;
              lineLength = 0;
            }
          }

          yield return Environment.NewLine;
        }
      }
    }
  }
}
