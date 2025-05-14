#nullable disable
using System.Xml.Serialization;
using DevExpress.Utils;

namespace DevExpress.AvaloniaXpfDemo.ChartControlModules;

[XmlRoot("Comments")]
public class CommentsData : List<CommentsInfo> {
    public static CommentsData Load() {
        return SafeXml.Deserialize<CommentsData>(DataProvider.GetCommentsDataStream());
    }
}


public class CommentsInfo {
    public string Category { get; set; }
    public List<CommentInfo> Items { get; set; }
}


public class CommentInfo {
    public DateTime Date { get; set; }
    public int CommentCount { get; set; }
}