using System;

using Xmpp.Xml.Dom;

namespace Xmpp.protocol.extensions.bookmarks
{
    /// <summary>
    /// Annotations are stored using server-side private XML storage. 
    /// A storage element contains a collection of one or more notes elements, 
    /// each representing a note about a given entity.
    /// </summary>
    public class RosterNote : Element
    {
        /*
             <iq type='result' id='a2'>
                <query xmlns='jabber:iq:private'>
                    <storage xmlns='storage:rosternotes'>
                        <note jid='hamlet@shakespeare.lit'
                            cdate='2004-09-24T15:23:21Z'
                            mdate='2004-09-24T15:23:21Z'>Seems to be a good writer</note>
                        <note jid='juliet@capulet.com'
                            cdate='2004-09-27T17:23:14Z'
                            mdate='2004-09-28T12:43:12Z'>Oh my sweetest love ...</note>
                    </storage>
                </query>
            </iq> 
         */
        public RosterNote()
        {
            TagName    = "note";
            Namespace = Uri.STORAGE_ROSTERNOTES;
        }


        public RosterNote(Jid jid, DateTime cdate, DateTime mdate, string note) : this()
        {
            Jid = jid;
            CreationDate = cdate;
            ModificationDate = mdate;
            Value = note;
        }

        /// <summary>
        /// Creation date time
        /// </summary>
        public DateTime CreationDate
        {
            get { return Util.Time.ISO_8601Date(GetAttribute("cdate")); }
            set { SetAttribute("cdate", Util.Time.ISO_8601Date(value)); }
        }

        /// <summary>
        /// Modification date tiime
        /// </summary>
        public DateTime ModificationDate
        {
            get { return Util.Time.ISO_8601Date(GetAttribute("mdate")); }
            set { SetAttribute("mdate", Util.Time.ISO_8601Date(value)); }
        }

        /// <summary>
        /// The Jid of the bookmarked room
        /// </summary>
        public Jid Jid
        {
            get { return GetAttributeJid("jid"); }
            set { SetAttribute("jid", value); }
        }
    }
}