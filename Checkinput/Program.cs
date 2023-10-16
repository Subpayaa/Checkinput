using System.Text.RegularExpressions;

class Program
{

    public class ResultModel
    {
        public bool status { get; set; }
        public string message { get; set; }
    }

    static void Main()
    {
        try
        {
            string userInput;
            var result = new ResultModel
            {
                status = true,
                message = "Pass"
            };

            Console.Write("Enter a Character: ");
            userInput = Console.ReadLine();

            CheckInputLength(userInput, result);
            Console.WriteLine(result.message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static bool CheckInputLength(string userInput, ResultModel result)
    {
        int minLength = 4;
        int maxLength = 25;

        if (userInput.Length >= minLength && userInput.Length <= maxLength)
        {
            CheckFirstCharacter(userInput, result);
        }
        else
        {
            result.status = false;
            result.message = "Input string valid length range 4 - 25";
        }
        return result.status;
    }

    private static bool CheckFirstCharacter(string userInput, ResultModel result)
    {
        var pattern = new Regex("^[a-zA-Z]*$");
        var inputfirst = userInput.FirstOrDefault().ToString();

        if (pattern.IsMatch(inputfirst))
        {
            CheckCharacter(userInput, result);
        }
        else
        {
            result.status = false;
            result.message = "Input string valid first character is text";
        }
        return result.status;
    }

    private static bool CheckCharacter(string userInput, ResultModel result)
    {
        var pattern = new Regex("^[a-zA-Z0-9_]*$");
        if (pattern.IsMatch(userInput))
        {
            CheckLastCharacter(userInput, result);
        }
        else
        {
            result.status = false;
            result.message = "Input string valid character and number and _";
        }
        return result.status;
    }

    private static bool CheckLastCharacter(string userInput, ResultModel result)
    {
        if (userInput.LastOrDefault().ToString() == "_")
        {
            result.status = false;
            result.message = "Input string valid Last character not _";
        }
        return result.status;
    }
}