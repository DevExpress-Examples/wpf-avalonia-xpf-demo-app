#nullable disable
#pragma warning disable DX0008
namespace DevExpress.AvaloniaXpfDemo.DemoData.Serialization.GeneratedSerializers.EmployeesData {

    public class XmlSerializationWriterEmployeesData : System.Xml.Serialization.XmlSerializationWriter {

        public void Write3_Employees(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"Employees", @"");
                return;
            }
            TopLevelElement();
            {
                global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData a = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)((global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)o);
                if ((object)(a) == null) {
                    WriteNullTagLiteral(@"Employees", @"");
                }
                else {
                    WriteStartElement(@"Employees", @"", null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        Write2_Employee(@"Employee", @"", ((global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee)a[ia]), true, false);
                    }
                    WriteEndElement();
                }
            }
        }

        void Write2_Employee(string n, string ns, global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Employee", @"");
            WriteElementStringRaw(@"Id", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@Id)));
            WriteElementStringRaw(@"ParentId", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@ParentId)));
            WriteElementString(@"FirstName", @"", ((global::System.String)o.@FirstName));
            WriteElementString(@"MiddleName", @"", ((global::System.String)o.@MiddleName));
            WriteElementString(@"LastName", @"", ((global::System.String)o.@LastName));
            WriteElementString(@"JobTitle", @"", ((global::System.String)o.@JobTitle));
            WriteElementString(@"Phone", @"", ((global::System.String)o.@Phone));
            WriteElementString(@"EmailAddress", @"", ((global::System.String)o.@EmailAddress));
            WriteElementString(@"AddressLine1", @"", ((global::System.String)o.@AddressLine1));
            WriteElementString(@"City", @"", ((global::System.String)o.@City));
            WriteElementString(@"StateProvinceName", @"", ((global::System.String)o.@StateProvinceName));
            WriteElementString(@"PostalCode", @"", ((global::System.String)o.@PostalCode));
            WriteElementString(@"CountryRegionName", @"", ((global::System.String)o.@CountryRegionName));
            WriteElementString(@"GroupName", @"", ((global::System.String)o.@GroupName));
            WriteElementStringRaw(@"BirthDate", @"", FromDateTime(((global::System.DateTime)o.@BirthDate)));
            WriteElementStringRaw(@"HireDate", @"", FromDateTime(((global::System.DateTime)o.@HireDate)));
            WriteElementString(@"Gender", @"", ((global::System.String)o.@Gender));
            WriteElementString(@"MaritalStatus", @"", ((global::System.String)o.@MaritalStatus));
            WriteElementString(@"Title", @"", ((global::System.String)o.@Title));
            WriteElementStringRaw(@"ImageData", @"", FromByteArrayBase64(((global::System.Byte[])o.@ImageData)));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderEmployeesData : System.Xml.Serialization.XmlSerializationReader {

        public object Read3_Employees() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_Employees && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    if (!ReadNull()) {
                        if ((object)(o) == null) o = new global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData();
                        global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData a_0_0 = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)o;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations0 = 0;
                            int readerCount0 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id3_Employee && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                        if ((object)(a_0_0) == null) Reader.Skip(); else a_0_0.Add(Read2_Employee(true, true));
                                    }
                                    else {
                                        UnknownNode(null, @":Employee");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":Employee");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations0, ref readerCount0);
                            }
                        ReadEndElement();
                        }
                    }
                    else {
                        if ((object)(o) == null) o = new global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData();
                        global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData a_0_0 = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)o;
                    }
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, @":Employees");
            }
            return (object)o;
        }

        global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee Read2_Employee(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_Employee && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee o;
            o = new global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee();
            bool[] paramsRead = new bool[20];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id4_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Id = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id5_ParentId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@ParentId = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id6_FirstName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@FirstName = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id7_MiddleName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@MiddleName = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id8_LastName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@LastName = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id9_JobTitle && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@JobTitle = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id10_Phone && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Phone = Reader.ReadElementString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id11_EmailAddress && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@EmailAddress = Reader.ReadElementString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id12_AddressLine1 && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@AddressLine1 = Reader.ReadElementString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id13_City && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@City = Reader.ReadElementString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id14_StateProvinceName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@StateProvinceName = Reader.ReadElementString();
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id15_PostalCode && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@PostalCode = Reader.ReadElementString();
                        }
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id16_CountryRegionName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@CountryRegionName = Reader.ReadElementString();
                        }
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id17_GroupName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@GroupName = Reader.ReadElementString();
                        }
                        paramsRead[13] = true;
                    }
                    else if (!paramsRead[14] && ((object) Reader.LocalName == (object)id18_BirthDate && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@BirthDate = ToDateTime(Reader.ReadElementString());
                        }
                        paramsRead[14] = true;
                    }
                    else if (!paramsRead[15] && ((object) Reader.LocalName == (object)id19_HireDate && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@HireDate = ToDateTime(Reader.ReadElementString());
                        }
                        paramsRead[15] = true;
                    }
                    else if (!paramsRead[16] && ((object) Reader.LocalName == (object)id20_Gender && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Gender = Reader.ReadElementString();
                        }
                        paramsRead[16] = true;
                    }
                    else if (!paramsRead[17] && ((object) Reader.LocalName == (object)id21_MaritalStatus && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@MaritalStatus = Reader.ReadElementString();
                        }
                        paramsRead[17] = true;
                    }
                    else if (!paramsRead[18] && ((object) Reader.LocalName == (object)id22_Title && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Title = Reader.ReadElementString();
                        }
                        paramsRead[18] = true;
                    }
                    else if (!paramsRead[19] && ((object) Reader.LocalName == (object)id23_ImageData && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@ImageData = ToByteArrayBase64(false);
                        }
                        paramsRead[19] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Id, :ParentId, :FirstName, :MiddleName, :LastName, :JobTitle, :Phone, :EmailAddress, :AddressLine1, :City, :StateProvinceName, :PostalCode, :CountryRegionName, :GroupName, :BirthDate, :HireDate, :Gender, :MaritalStatus, :Title, :ImageData");
                    }
                }
                else {
                    UnknownNode((object)o, @":Id, :ParentId, :FirstName, :MiddleName, :LastName, :JobTitle, :Phone, :EmailAddress, :AddressLine1, :City, :StateProvinceName, :PostalCode, :CountryRegionName, :GroupName, :BirthDate, :HireDate, :Gender, :MaritalStatus, :Title, :ImageData");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id10_Phone;
        string id11_EmailAddress;
        string id21_MaritalStatus;
        string id18_BirthDate;
        string id8_LastName;
        string id16_CountryRegionName;
        string id3_Employee;
        string id20_Gender;
        string id12_AddressLine1;
        string id15_PostalCode;
        string id4_Id;
        string id22_Title;
        string id6_FirstName;
        string id1_Employees;
        string id23_ImageData;
        string id2_Item;
        string id14_StateProvinceName;
        string id7_MiddleName;
        string id9_JobTitle;
        string id19_HireDate;
        string id17_GroupName;
        string id13_City;
        string id5_ParentId;

        protected override void InitIDs() {
            id10_Phone = Reader.NameTable.Add(@"Phone");
            id11_EmailAddress = Reader.NameTable.Add(@"EmailAddress");
            id21_MaritalStatus = Reader.NameTable.Add(@"MaritalStatus");
            id18_BirthDate = Reader.NameTable.Add(@"BirthDate");
            id8_LastName = Reader.NameTable.Add(@"LastName");
            id16_CountryRegionName = Reader.NameTable.Add(@"CountryRegionName");
            id3_Employee = Reader.NameTable.Add(@"Employee");
            id20_Gender = Reader.NameTable.Add(@"Gender");
            id12_AddressLine1 = Reader.NameTable.Add(@"AddressLine1");
            id15_PostalCode = Reader.NameTable.Add(@"PostalCode");
            id4_Id = Reader.NameTable.Add(@"Id");
            id22_Title = Reader.NameTable.Add(@"Title");
            id6_FirstName = Reader.NameTable.Add(@"FirstName");
            id1_Employees = Reader.NameTable.Add(@"Employees");
            id23_ImageData = Reader.NameTable.Add(@"ImageData");
            id2_Item = Reader.NameTable.Add(@"");
            id14_StateProvinceName = Reader.NameTable.Add(@"StateProvinceName");
            id7_MiddleName = Reader.NameTable.Add(@"MiddleName");
            id9_JobTitle = Reader.NameTable.Add(@"JobTitle");
            id19_HireDate = Reader.NameTable.Add(@"HireDate");
            id17_GroupName = Reader.NameTable.Add(@"GroupName");
            id13_City = Reader.NameTable.Add(@"City");
            id5_ParentId = Reader.NameTable.Add(@"ParentId");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReaderEmployeesData();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriterEmployeesData();
        }
    }

    public sealed class EmployeesDataSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Employees", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterEmployeesData)writer).Write3_Employees(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderEmployeesData)reader).Read3_Employees();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderEmployeesData(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterEmployeesData(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData::Employees:True:"] = @"Read3_Employees";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData::Employees:True:"] = @"Write3_Employees";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData::Employees:True:", new EmployeesDataSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesData)) return new EmployeesDataSerializer();
            return null;
        }
    }
}
namespace DevExpress.AvaloniaXpfDemo.DemoData.Serialization.GeneratedSerializers.EmployeesWithPhotoData {

    public class XmlSerializationWriterEmployeesWithPhotoData : System.Xml.Serialization.XmlSerializationWriter {

        public void Write3_Employees(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"Employees", @"");
                return;
            }
            TopLevelElement();
            {
                global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData a = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)((global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)o);
                if ((object)(a) == null) {
                    WriteNullTagLiteral(@"Employees", @"");
                }
                else {
                    WriteStartElement(@"Employees", @"", null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        Write2_Employee(@"Employee", @"", ((global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee)a[ia]), true, false);
                    }
                    WriteEndElement();
                }
            }
        }

        void Write2_Employee(string n, string ns, global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Employee", @"");
            WriteElementStringRaw(@"Id", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@Id)));
            WriteElementStringRaw(@"ParentId", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@ParentId)));
            WriteElementString(@"FirstName", @"", ((global::System.String)o.@FirstName));
            WriteElementString(@"MiddleName", @"", ((global::System.String)o.@MiddleName));
            WriteElementString(@"LastName", @"", ((global::System.String)o.@LastName));
            WriteElementString(@"JobTitle", @"", ((global::System.String)o.@JobTitle));
            WriteElementString(@"Phone", @"", ((global::System.String)o.@Phone));
            WriteElementString(@"EmailAddress", @"", ((global::System.String)o.@EmailAddress));
            WriteElementString(@"AddressLine1", @"", ((global::System.String)o.@AddressLine1));
            WriteElementString(@"City", @"", ((global::System.String)o.@City));
            WriteElementString(@"StateProvinceName", @"", ((global::System.String)o.@StateProvinceName));
            WriteElementString(@"PostalCode", @"", ((global::System.String)o.@PostalCode));
            WriteElementString(@"CountryRegionName", @"", ((global::System.String)o.@CountryRegionName));
            WriteElementString(@"GroupName", @"", ((global::System.String)o.@GroupName));
            WriteElementStringRaw(@"BirthDate", @"", FromDateTime(((global::System.DateTime)o.@BirthDate)));
            WriteElementStringRaw(@"HireDate", @"", FromDateTime(((global::System.DateTime)o.@HireDate)));
            WriteElementString(@"Gender", @"", ((global::System.String)o.@Gender));
            WriteElementString(@"MaritalStatus", @"", ((global::System.String)o.@MaritalStatus));
            WriteElementString(@"Title", @"", ((global::System.String)o.@Title));
            WriteElementStringRaw(@"ImageData", @"", FromByteArrayBase64(((global::System.Byte[])o.@ImageData)));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderEmployeesWithPhotoData : System.Xml.Serialization.XmlSerializationReader {

        public object Read3_Employees() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_Employees && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    if (!ReadNull()) {
                        if ((object)(o) == null) o = new global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData();
                        global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData a_0_0 = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)o;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations0 = 0;
                            int readerCount0 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id3_Employee && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                        if ((object)(a_0_0) == null) Reader.Skip(); else a_0_0.Add(Read2_Employee(true, true));
                                    }
                                    else {
                                        UnknownNode(null, @":Employee");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":Employee");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations0, ref readerCount0);
                            }
                        ReadEndElement();
                        }
                    }
                    else {
                        if ((object)(o) == null) o = new global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData();
                        global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData a_0_0 = (global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)o;
                    }
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, @":Employees");
            }
            return (object)o;
        }

        global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee Read2_Employee(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_Employee && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee o;
            o = new global::DevExpress.AvaloniaXpfDemo.DemoData.Employees.Employee();
            bool[] paramsRead = new bool[20];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id4_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Id = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id5_ParentId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@ParentId = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id6_FirstName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@FirstName = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id7_MiddleName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@MiddleName = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id8_LastName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@LastName = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id9_JobTitle && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@JobTitle = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id10_Phone && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Phone = Reader.ReadElementString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id11_EmailAddress && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@EmailAddress = Reader.ReadElementString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id12_AddressLine1 && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@AddressLine1 = Reader.ReadElementString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id13_City && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@City = Reader.ReadElementString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id14_StateProvinceName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@StateProvinceName = Reader.ReadElementString();
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id15_PostalCode && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@PostalCode = Reader.ReadElementString();
                        }
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id16_CountryRegionName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@CountryRegionName = Reader.ReadElementString();
                        }
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id17_GroupName && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@GroupName = Reader.ReadElementString();
                        }
                        paramsRead[13] = true;
                    }
                    else if (!paramsRead[14] && ((object) Reader.LocalName == (object)id18_BirthDate && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@BirthDate = ToDateTime(Reader.ReadElementString());
                        }
                        paramsRead[14] = true;
                    }
                    else if (!paramsRead[15] && ((object) Reader.LocalName == (object)id19_HireDate && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@HireDate = ToDateTime(Reader.ReadElementString());
                        }
                        paramsRead[15] = true;
                    }
                    else if (!paramsRead[16] && ((object) Reader.LocalName == (object)id20_Gender && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Gender = Reader.ReadElementString();
                        }
                        paramsRead[16] = true;
                    }
                    else if (!paramsRead[17] && ((object) Reader.LocalName == (object)id21_MaritalStatus && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@MaritalStatus = Reader.ReadElementString();
                        }
                        paramsRead[17] = true;
                    }
                    else if (!paramsRead[18] && ((object) Reader.LocalName == (object)id22_Title && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Title = Reader.ReadElementString();
                        }
                        paramsRead[18] = true;
                    }
                    else if (!paramsRead[19] && ((object) Reader.LocalName == (object)id23_ImageData && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@ImageData = ToByteArrayBase64(false);
                        }
                        paramsRead[19] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Id, :ParentId, :FirstName, :MiddleName, :LastName, :JobTitle, :Phone, :EmailAddress, :AddressLine1, :City, :StateProvinceName, :PostalCode, :CountryRegionName, :GroupName, :BirthDate, :HireDate, :Gender, :MaritalStatus, :Title, :ImageData");
                    }
                }
                else {
                    UnknownNode((object)o, @":Id, :ParentId, :FirstName, :MiddleName, :LastName, :JobTitle, :Phone, :EmailAddress, :AddressLine1, :City, :StateProvinceName, :PostalCode, :CountryRegionName, :GroupName, :BirthDate, :HireDate, :Gender, :MaritalStatus, :Title, :ImageData");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id10_Phone;
        string id11_EmailAddress;
        string id21_MaritalStatus;
        string id18_BirthDate;
        string id8_LastName;
        string id16_CountryRegionName;
        string id3_Employee;
        string id20_Gender;
        string id12_AddressLine1;
        string id15_PostalCode;
        string id4_Id;
        string id22_Title;
        string id6_FirstName;
        string id1_Employees;
        string id23_ImageData;
        string id2_Item;
        string id14_StateProvinceName;
        string id7_MiddleName;
        string id9_JobTitle;
        string id19_HireDate;
        string id17_GroupName;
        string id13_City;
        string id5_ParentId;

        protected override void InitIDs() {
            id10_Phone = Reader.NameTable.Add(@"Phone");
            id11_EmailAddress = Reader.NameTable.Add(@"EmailAddress");
            id21_MaritalStatus = Reader.NameTable.Add(@"MaritalStatus");
            id18_BirthDate = Reader.NameTable.Add(@"BirthDate");
            id8_LastName = Reader.NameTable.Add(@"LastName");
            id16_CountryRegionName = Reader.NameTable.Add(@"CountryRegionName");
            id3_Employee = Reader.NameTable.Add(@"Employee");
            id20_Gender = Reader.NameTable.Add(@"Gender");
            id12_AddressLine1 = Reader.NameTable.Add(@"AddressLine1");
            id15_PostalCode = Reader.NameTable.Add(@"PostalCode");
            id4_Id = Reader.NameTable.Add(@"Id");
            id22_Title = Reader.NameTable.Add(@"Title");
            id6_FirstName = Reader.NameTable.Add(@"FirstName");
            id1_Employees = Reader.NameTable.Add(@"Employees");
            id23_ImageData = Reader.NameTable.Add(@"ImageData");
            id2_Item = Reader.NameTable.Add(@"");
            id14_StateProvinceName = Reader.NameTable.Add(@"StateProvinceName");
            id7_MiddleName = Reader.NameTable.Add(@"MiddleName");
            id9_JobTitle = Reader.NameTable.Add(@"JobTitle");
            id19_HireDate = Reader.NameTable.Add(@"HireDate");
            id17_GroupName = Reader.NameTable.Add(@"GroupName");
            id13_City = Reader.NameTable.Add(@"City");
            id5_ParentId = Reader.NameTable.Add(@"ParentId");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReaderEmployeesWithPhotoData();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriterEmployeesWithPhotoData();
        }
    }

    public sealed class EmployeesWithPhotoDataSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Employees", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterEmployeesWithPhotoData)writer).Write3_Employees(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderEmployeesWithPhotoData)reader).Read3_Employees();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderEmployeesWithPhotoData(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterEmployeesWithPhotoData(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData::Employees:True:"] = @"Read3_Employees";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData::Employees:True:"] = @"Write3_Employees";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData::Employees:True:", new EmployeesWithPhotoDataSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.EmployeesWithPhotoData)) return new EmployeesWithPhotoDataSerializer();
            return null;
        }
    }
}
namespace DevExpress.AvaloniaXpfDemo.DemoData.Serialization.GeneratedSerializers.NWindOrderToNewEmployeeArray {

    public class XmlSerializationWriterNWindOrderToNewEmployeeArray : System.Xml.Serialization.XmlSerializationWriter {

        public void Write3_ArrayOfNWindOrderToNewEmployee(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"ArrayOfNWindOrderToNewEmployee", @"");
                return;
            }
            TopLevelElement();
            {
                global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[] a = (global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])((global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])o);
                if ((object)(a) == null) {
                    WriteNullTagLiteral(@"ArrayOfNWindOrderToNewEmployee", @"");
                }
                else {
                    WriteStartElement(@"ArrayOfNWindOrderToNewEmployee", @"", null, false);
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write2_NWindOrderToNewEmployee(@"NWindOrderToNewEmployee", @"", ((global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee)a[ia]), true, false);
                    }
                    WriteEndElement();
                }
            }
        }

        void Write2_NWindOrderToNewEmployee(string n, string ns, global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"NWindOrderToNewEmployee", @"");
            WriteElementStringRaw(@"NWindOrderId", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@NWindOrderId)));
            WriteElementStringRaw(@"EmployeeId", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@EmployeeId)));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderNWindOrderToNewEmployeeArray : System.Xml.Serialization.XmlSerializationReader {

        public object Read3_ArrayOfNWindOrderToNewEmployee() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_ArrayOfNWindOrderToNewEmployee && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    if (!ReadNull()) {
                        global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[] a_0_0 = null;
                        int ca_0_0 = 0;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations0 = 0;
                            int readerCount0 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id3_NWindOrderToNewEmployee && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                        a_0_0 = (global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee));a_0_0[ca_0_0++] = Read2_NWindOrderToNewEmployee(true, true);
                                    }
                                    else {
                                        UnknownNode(null, @":NWindOrderToNewEmployee");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":NWindOrderToNewEmployee");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations0, ref readerCount0);
                            }
                        ReadEndElement();
                        }
                        o = (global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])ShrinkArray(a_0_0, ca_0_0, typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee), false);
                    }
                    else {
                        global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[] a_0_0 = null;
                        int ca_0_0 = 0;
                        o = (global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])ShrinkArray(a_0_0, ca_0_0, typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee), true);
                    }
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, @":ArrayOfNWindOrderToNewEmployee");
            }
            return (object)o;
        }

        global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee Read2_NWindOrderToNewEmployee(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_NWindOrderToNewEmployee && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee o;
            o = new global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id4_NWindOrderId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@NWindOrderId = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id5_EmployeeId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@EmployeeId = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":NWindOrderId, :EmployeeId");
                    }
                }
                else {
                    UnknownNode((object)o, @":NWindOrderId, :EmployeeId");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id1_ArrayOfNWindOrderToNewEmployee;
        string id4_NWindOrderId;
        string id5_EmployeeId;
        string id3_NWindOrderToNewEmployee;
        string id2_Item;

        protected override void InitIDs() {
            id1_ArrayOfNWindOrderToNewEmployee = Reader.NameTable.Add(@"ArrayOfNWindOrderToNewEmployee");
            id4_NWindOrderId = Reader.NameTable.Add(@"NWindOrderId");
            id5_EmployeeId = Reader.NameTable.Add(@"EmployeeId");
            id3_NWindOrderToNewEmployee = Reader.NameTable.Add(@"NWindOrderToNewEmployee");
            id2_Item = Reader.NameTable.Add(@"");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReaderNWindOrderToNewEmployeeArray();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriterNWindOrderToNewEmployeeArray();
        }
    }

    public sealed class ArrayOfNWindOrderToNewEmployeeSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ArrayOfNWindOrderToNewEmployee", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterNWindOrderToNewEmployeeArray)writer).Write3_ArrayOfNWindOrderToNewEmployee(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderNWindOrderToNewEmployeeArray)reader).Read3_ArrayOfNWindOrderToNewEmployee();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderNWindOrderToNewEmployeeArray(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterNWindOrderToNewEmployeeArray(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[]::"] = @"Read3_ArrayOfNWindOrderToNewEmployee";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[]::"] = @"Write3_ArrayOfNWindOrderToNewEmployee";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[]::", new ArrayOfNWindOrderToNewEmployeeSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::DevExpress.AvaloniaXpfDemo.DemoData.NWindOrderToNewEmployee[])) return new ArrayOfNWindOrderToNewEmployeeSerializer();
            return null;
        }
    }
}
#pragma warning restore DX0008