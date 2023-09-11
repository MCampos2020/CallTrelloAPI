using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMJVCallAPI
{
    using System;

    public class CardUpdate
    {
        public string Id { get; set; }
        public string IdMemberCreator { get; set; }
        public Data Data { get; set; }
        public string AppCreator { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public object Limits { get; set; }
        public Display Display { get; set; }
        public MemberCreator MemberCreator { get; set; }
    }

    public class Data
    {
        public ListData List { get; set; }
        public Board Board { get; set; }
        public Card Card { get; set; }
        public Old Old { get; set; }
    }

    public class ListData
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Board
    {
        public string ShortLink { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Card
    {
        public string ShortLink { get; set; }
        public int IdShort { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Due { get; set; }
    }

    public class Old
    {
        public DateTime Due { get; set; }
    }

    public class Display
    {
        public string TranslationKey { get; set; }
        public Entities Entities { get; set; }
    }

    public class Entities
    {
        public CardEntity Card { get; set; }
        public DateEntity Date { get; set; }
        public MemberCreatorEntity MemberCreator { get; set; }
    }

    public class CardEntity
    {
        public string Type { get; set; }
        public string ShortLink { get; set; }
        public string Id { get; set; }
        public DateTime Due { get; set; }
        public string Text { get; set; }
    }

    public class DateEntity
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class MemberCreatorEntity
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }

    public class MemberCreator
    {
        public string Id { get; set; }
        public bool ActivityBlocked { get; set; }
        public string AvatarHash { get; set; }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public object IdMemberReferrer { get; set; }
        public string Initials { get; set; }
        public object NonPublic { get; set; }
        public bool NonPublicAvailable { get; set; }
        public string Username { get; set; }
    }

}
