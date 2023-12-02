using System.ComponentModel.DataAnnotations;

namespace CustomExtensions
{
  //Extension methods must be defined in a static class
  public static class StringExtension
  {
    // This is the extension method.
    // The first parameter takes the "this" modifier
    // and specifies the type for which the method is defined.

    public static string Flip(this string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

    public static int firstNumber(this string s)
    {
      char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
      int _firstDigitLocation = s.IndexOfAny(digits);
      char x = s[_firstDigitLocation];
      string _firstDigitString = $"{x}";
      int.TryParse(_firstDigitString, out int _firstDigit);

      string[] digitStrings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
      Dictionary<string, int> numbers = new Dictionary<string, int>{
        {"zero",0},
        {"one",1 },
        {"two",2},
        {"three",3},
        {"four", 4},
        {"five",5},
        {"six",6},
        {"seven",7 },
        {"eight",8},
        {"nine",9}
      };

      var _stuff = new SortedList<int, string>();
      foreach (var d in digitStrings)
      {
        if (s.IndexOf(d) > -1)
        {
          _stuff.Add(s.IndexOf(d), d);
        }
      }

      if (_stuff.Any())
      {
        if (_firstDigitLocation < _stuff.First().Key)
        { return _firstDigit; }
        else
        { return numbers[_stuff.First().Value]; };
      }
      { return _firstDigit; }
    }

    public static int lastNumber(this string s)
    {
      char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
      string _sFlipped = s.Flip();
      int _lastDigitLocation = s.Length - _sFlipped.IndexOfAny(digits) - 1;
      char x = s[_lastDigitLocation];
      string _lastDigitString = $"{x}";
      int.TryParse(_lastDigitString, out int _lastDigit);

      string[] digitStrings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
      Dictionary<string, int> numbers = new Dictionary<string, int>{
        {"zero",0},
        {"one",1 },
        {"two",2},
        {"three",3},
        {"four", 4},
        {"five",5},
        {"six",6},
        {"seven",7 },
        {"eight",8},
        {"nine",9}
      };

      var _stuff = new SortedList<int, string>();
      foreach (var d in digitStrings)
      {
        for (int strStart = s.Length-1; strStart > 1; strStart--)
        {
          string endString = s.Substring(strStart-1, s.Length-strStart+1);
          if (endString.IndexOf(d) > -1)
          {
            _stuff.Add(strStart, d);
            break;
          }
        }
      }

      if (_stuff.Any())
      {
        if (_lastDigitLocation > _stuff.Last().Key)
        { return _lastDigit; }
        else
        { return numbers[_stuff.Last().Value]; };
      }
      return _lastDigit;
    }
  }
}