using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Ink;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BoardApp.Models
{
    public partial class UserModel : IData
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Boards")]
        public List<Board> Boards { get; set; }

        public UserModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Boards = new();
        }
    }

    public partial class Board : IData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Strokes")]
        public string Strokes { get; set; }
        //public List<Stroke> Strokes { get; set; }
    }

    //public partial class Stroke
    //{
    //    [JsonProperty("DrawingAttributes")]
    //    public DrawingAttributes DrawingAttributes { get; set; }

    //    [JsonProperty("StylusPoints")]
    //    public List<StylusPoint> StylusPoints { get; set; }
    //}

    //public partial class DrawingAttributes
    //{
    //    [JsonProperty("Color")]
    //    public Dictionary<string, long?> Color { get; set; }

    //    [JsonProperty("StylusTip")]
    //    public long StylusTip { get; set; }

    //    [JsonProperty("StylusTipTransform")]
    //    public StylusTipTransform StylusTipTransform { get; set; }

    //    [JsonProperty("Height")]
    //    public double Height { get; set; }

    //    [JsonProperty("Width")]
    //    public double Width { get; set; }

    //    [JsonProperty("FitToCurve")]
    //    public bool FitToCurve { get; set; }

    //    [JsonProperty("IgnorePressure")]
    //    public bool IgnorePressure { get; set; }

    //    [JsonProperty("IsHighlighter")]
    //    public bool IsHighlighter { get; set; }
    //}

    //public partial class StylusTipTransform
    //{
    //    [JsonProperty("IsIdentity")]
    //    public bool IsIdentity { get; set; }

    //    [JsonProperty("Determinant")]
    //    public long Determinant { get; set; }

    //    [JsonProperty("HasInverse")]
    //    public bool HasInverse { get; set; }

    //    [JsonProperty("M11")]
    //    public long M11 { get; set; }

    //    [JsonProperty("M12")]
    //    public long M12 { get; set; }

    //    [JsonProperty("M21")]
    //    public long M21 { get; set; }

    //    [JsonProperty("M22")]
    //    public long M22 { get; set; }

    //    [JsonProperty("OffsetX")]
    //    public long OffsetX { get; set; }

    //    [JsonProperty("OffsetY")]
    //    public long OffsetY { get; set; }
    //}

    //public partial class StylusPoint
    //{
    //    [JsonProperty("X")]
    //    public long X { get; set; }

    //    [JsonProperty("Y")]
    //    public long Y { get; set; }

    //    [JsonProperty("PressureFactor")]
    //    public double PressureFactor { get; set; }

    //    [JsonProperty("Description")]
    //    public Description Description { get; set; }
    //}

    //public partial class Description
    //{
    //    [JsonProperty("PropertyCount")]
    //    public long PropertyCount { get; set; }
    //}
}