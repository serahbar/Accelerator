using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accelerator.Infrastructures.Data.SqlServer
{
    public class AcceleratorDbContext : DbContext
    {
        public AcceleratorDbContext(DbContextOptions<AcceleratorDbContext> options)
            : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
           new Author("Berry", "Griffin Beak Eldritch", "Ships")
           {
               Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
               DateOfBirth = new DateTime(1980, 7, 23),
               AuthorType = AuthorType.First

           },
           new Author("Nancy", "Swashbuckler Rye", "Rum")
           {
               Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
               DateOfBirth = new DateTime(1978, 5, 21),
               AuthorType = AuthorType.First

           },
           new Author("Eli", "Ivory Bones Sweet", "Singing")
           {
               Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
               DateOfBirth = new DateTime(1957, 12, 16),
               AuthorType = AuthorType.First
           },
           new Author("Arnold", "The Unseen Stafford", "Singing")
           {
               Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
               DateOfBirth = new DateTime(1957, 3, 6),
               AuthorType = AuthorType.First
           },
           new Author("Seabury", "Toxic Reyson", "Maps")
           {
               Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
               DateOfBirth = new DateTime(1956, 11, 23),
               AuthorType = AuthorType.Second
           },
           new Author("Rutherford", "Fearless Cloven", "General debauchery")
           {
               Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
               DateOfBirth = new DateTime(1981, 4, 5),
               AuthorType = AuthorType.Second
           },
           new Author("Atherton", "Crow Ridley", "Rum")
           {
               Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
               DateOfBirth = new DateTime(1982, 10, 11),
               AuthorType = AuthorType.Third
           },
           new Author("Noble", "Harvey", "Ships")
           {
               Id = Guid.Parse("EEC4777E-50A5-EF18-C335-952D65415437"),
               DateOfBirth = DateTime.Parse("15/07/1992"),
               AuthorType = 0,
           },
           new Author("Xavier", "Aguirre", "Ships")
           {
               Id = Guid.Parse("18C215AB-3282-5D51-AC65-B99DCDD18A7C"),
               DateOfBirth = DateTime.Parse("21/10/2020"),
               AuthorType = AuthorType.Second,
           },
           new Author("Paula", "Santiago", "Maps")
           {
               Id = Guid.Parse("249505F4-DCB8-96E7-988B-B87F36BA9DDF"),
               DateOfBirth = DateTime.Parse("30/06/2021"),
               AuthorType = 0,
           },
           new Author("Rhonda", "Aguilar", "Maps")
           {
               Id = Guid.Parse("CABC6290-78E1-E8C9-E344-ACA28C17B455"),
               DateOfBirth = DateTime.Parse("03/04/2017"),
               AuthorType = 0,
           },
           new Author("Isabella", "Byrd", "Ships")
           {
               Id = Guid.Parse("DB226789-6B88-EB1D-65BA-DAE34B57A638"),
               DateOfBirth = DateTime.Parse("01/01/2002"),
               AuthorType = 0,
           },
           new Author("Urielle", "Morris", "General debauchery")
           {
               Id = Guid.Parse("3F93AE30-3EEB-26E1-D578-ECB03751221A"),
               DateOfBirth = DateTime.Parse("15/07/2018"),
               AuthorType = 0,
           },
           new Author("Rina", "Bullock", "Maps")
           {
               Id = Guid.Parse("18995FD9-3945-86AC-DCD2-C975EA3059EB"),
               DateOfBirth = DateTime.Parse("31/05/2016"),
               AuthorType = AuthorType.Second,
           },
           new Author("Jayme", "Henson", "Maps")
           {
               Id = Guid.Parse("D9E5C98E-D5A8-C15F-EB6D-56574C65E37F"),
               DateOfBirth = DateTime.Parse("07/01/1998"),
               AuthorType = AuthorType.Second,
           },
           new Author("Carson", "Mcbride", "Rum")
           {
               Id = Guid.Parse("53349C64-97D3-A1B2-DD75-4C3B9EE8D7DF"),
               DateOfBirth = DateTime.Parse("31/05/1998"),
               AuthorType = AuthorType.Second,
           },
           new Author("Brady", "Jennings", "Rum")
           {
               Id = Guid.Parse("68436BA7-4EDC-51D6-BCB9-6EC46B3C475F"),
               DateOfBirth = DateTime.Parse("13/09/2010"),
               AuthorType = 0,
           },
           new Author("Andrew", "Cross", "General debauchery")
           {
               Id = Guid.Parse("147796A2-C39A-E47B-5954-E2B44ADAF42C"),
               DateOfBirth = DateTime.Parse("21/09/2003"),
               AuthorType = 0,
           },
           new Author("Lavinia", "Rasmussen", "Ships")
           {
               Id = Guid.Parse("4D4196B8-E1B7-BC57-8AEB-B61398D2ACAA"),
               DateOfBirth = DateTime.Parse("21/06/1992"),
               AuthorType = 0,
           },
           new Author("Indira", "Howell", "Rum")
           {
               Id = Guid.Parse("72F6662C-5622-30B8-C285-F8FA249BAD37"),
               DateOfBirth = DateTime.Parse("06/05/2014"),
               AuthorType = 0,
           },
           new Author("ser", "raha", "Rum")
           {
               Id = Guid.Parse("4E793432-2508-5B17-63B5-96DCD09B7FEC"),
               DateOfBirth = DateTime.Parse("25/12/2023"),
               AuthorType = 0,
           },
           new Author("Brady", "Palmer", "Maps")
           {
               Id = Guid.Parse("3575669A-8755-0367-471B-987BEB54D9AA"),
               DateOfBirth = DateTime.Parse("06/08/2000"),
               AuthorType = 0,
           },
           new Author("Daria", "Kline", "General debauchery")
           {
               Id = Guid.Parse("C7D5BA5A-A232-C5BB-1507-A21241E72448"),
               DateOfBirth = DateTime.Parse("14/11/1997"),
               AuthorType = 0,
           },
           new Author("Naomi", "Noble", "Ships")
           {
               Id = Guid.Parse("1AC69394-AF85-0777-DB5A-3C6FE9AB44D4"),
               DateOfBirth = DateTime.Parse("08/10/2020"),
               AuthorType = 0,
           },
           new Author("Hedwig", "Moreno", "Ships")
           {
               Id = Guid.Parse("B8D2D8D3-9B13-E5B6-67AB-AEAD82824C9F"),
               DateOfBirth = DateTime.Parse("10/03/1997"),
               AuthorType = 0,
           },
           new Author("Amery", "Haney", "General debauchery")
           {
               Id = Guid.Parse("DD3768BD-198E-E7D4-462B-F5553CEEA344"),
               DateOfBirth = DateTime.Parse("13/08/2001"),
               AuthorType = 0,
           },
           new Author("Zelda", "Grimes", "Ships")
           {
               Id = Guid.Parse("618CFAB2-A871-ED10-1673-F572763AEB40"),
               DateOfBirth = DateTime.Parse("20/09/1993"),
               AuthorType = 0,
           },
           new Author("Ishmael", "Fisher", "Rum")
           {
               Id = Guid.Parse("2A6877BB-3F83-9E2A-7811-598EA73EEE9F"),
               DateOfBirth = DateTime.Parse("18/05/2021"),
               AuthorType = AuthorType.Second,
           },
           new Author("Jacqueline", "Myers", "Singing")
           {
               Id = Guid.Parse("13A0609B-8219-9028-094A-6EE9D8ABAECD"),
               DateOfBirth = DateTime.Parse("01/04/2016"),
               AuthorType = AuthorType.Second,
           },
           new Author("Talon", "Merritt", "Maps")
           {
               Id = Guid.Parse("1E82325D-48A0-56F8-95C9-489D74269463"),
               DateOfBirth = DateTime.Parse("22/07/2009"),
               AuthorType = AuthorType.Second,
           },
           new Author("Frances", "Snyder", "Rum")
           {
               Id = Guid.Parse("A523A6A2-B33F-1A74-D61C-9B2EE01C4CEA"),
               DateOfBirth = DateTime.Parse("11/06/1997"),
               AuthorType = 0,
           },
           new Author("Rigel", "Hines", "Singing")
           {
               Id = Guid.Parse("14936E1D-D0A4-2832-DE46-B9AD7C534849"),
               DateOfBirth = DateTime.Parse("11/01/1997"),
               AuthorType = 0,
           },
           new Author("Abraham", "Henderson", "Ships")
           {
               Id = Guid.Parse("783A83BB-23A3-2B7E-7983-3314B2EAAABE"),
               DateOfBirth = DateTime.Parse("13/04/2019"),
               AuthorType = AuthorType.Second,
           },
           new Author("Gwendolyn", "Horton", "Maps")
           {
               Id = Guid.Parse("AAE87159-D165-1736-1C5E-A886C249597C"),
               DateOfBirth = DateTime.Parse("27/12/2018"),
               AuthorType = AuthorType.Second,
           },
           new Author("Carter", "Pruitt", "General debauchery")
           {
               Id = Guid.Parse("D3F365B0-02DD-1B91-CE93-593B9D4822FC"),
               DateOfBirth = DateTime.Parse("28/04/2021"),
               AuthorType = AuthorType.Second,
           },
           new Author("Margaret", "Wallace", "Ships")
           {
               Id = Guid.Parse("B4E9849E-78EC-0171-581D-6DE5EB9BE63B"),
               DateOfBirth = DateTime.Parse("03/11/2013"),
               AuthorType = AuthorType.Second,
           },
           new Author("Regan", "Hale", "Ships")
           {
               Id = Guid.Parse("17826344-091E-984A-E836-70996AF6077F"),
               DateOfBirth = DateTime.Parse("28/02/2001"),
               AuthorType = AuthorType.Second,
           },
           new Author("Petra", "Clayton", "Ships")
           {
               Id = Guid.Parse("E3DB99A3-E161-DF10-AAC6-A48EE55BCB8D"),
               DateOfBirth = DateTime.Parse("04/02/2008"),
               AuthorType = AuthorType.Second,
           },
           new Author("Hop", "Williamson", "General debauchery")
           {
               Id = Guid.Parse("418BCBE8-1495-903C-2E17-2C8B7C8AF152"),
               DateOfBirth = DateTime.Parse("24/07/2015"),
               AuthorType = AuthorType.Second,
           },
           new Author("Tobias", "Gonzales", "Rum")
           {
               Id = Guid.Parse("65385AD0-9D5B-09B3-4A4D-9A41F59D5E68"),
               DateOfBirth = DateTime.Parse("03/06/2004"),
               AuthorType = AuthorType.Second,
           },
           new Author("Brent", "Armstrong", "Singing")
           {
               Id = Guid.Parse("33ED24C7-9475-9BA7-2C88-71D0525AB351"),
               DateOfBirth = DateTime.Parse("01/09/2008"),
               AuthorType = AuthorType.Second,
           },
           new Author("Joy", "Petty", "Ships")
           {
               Id = Guid.Parse("5B36E532-C3D1-5893-FD44-81FAE4AE20EC"),
               DateOfBirth = DateTime.Parse("07/08/2019"),
               AuthorType = 0,
           },
           new Author("Thaddeus", "Martin", "Maps")
           {
               Id = Guid.Parse("D27ED8DC-C725-69E6-B947-A46FA3799737"),
               DateOfBirth = DateTime.Parse("27/04/2020"),
               AuthorType = 0,
           },
           new Author("Ariana", "Russell", "General debauchery")
           {
               Id = Guid.Parse("68A291A5-D9DE-2E4C-88A8-396BCB36E644"),
               DateOfBirth = DateTime.Parse("13/12/2021"),
               AuthorType = AuthorType.Second,
           },
           new Author("Clementine", "King", "Ships")
           {
               Id = Guid.Parse("B6BA1862-2740-5ED8-02C1-ED76ED39BBE5"),
               DateOfBirth = DateTime.Parse("14/11/2009"),
               AuthorType = AuthorType.Second,
           },
           new Author("Hadley", "Colon", "Maps")
           {
               Id = Guid.Parse("935A782B-ABB7-C1BD-CABB-13E52FC6D1E8"),
               DateOfBirth = DateTime.Parse("20/02/1993"),
               AuthorType = AuthorType.Second,
           },
           new Author("Hayden", "Mercado", "Maps")
           {
               Id = Guid.Parse("F23A2971-014C-9B5E-EE9D-389597F34EFE"),
               DateOfBirth = DateTime.Parse("25/12/2023"),
               AuthorType = 0,
           },
           new Author("Freya", "Burch", "General debauchery")
           {
               Id = Guid.Parse("B722E7A7-68CE-9A29-D36A-737453AE82A3"),
               DateOfBirth = DateTime.Parse("28/05/2005"),
               AuthorType = 0,
           },
           new Author("Shay", "Calhoun", "Maps")
           {
               Id = Guid.Parse("C2C92491-6175-EADD-6645-3CA7341435CB"),
               DateOfBirth = DateTime.Parse("13/10/2019"),
               AuthorType = 0,
           },
           new Author("Sydnee", "Hays", "Rum")
           {
               Id = Guid.Parse("681C4CC2-53B6-BBDE-1185-659768C6F338"),
               DateOfBirth = DateTime.Parse("21/06/2014"),
               AuthorType = 0,
           },
           new Author("Xandra", "Kent", "Singing")
           {
               Id = Guid.Parse("84135081-4A9F-B8EC-6373-1D19A6A3CC31"),
               DateOfBirth = DateTime.Parse("03/03/2005"),
               AuthorType = AuthorType.Second,
           },
           new Author("Donna", "Acevedo", "Singing")
           {
               Id = Guid.Parse("C4342CC3-4288-4FE6-827A-B2660403BC7E"),
               DateOfBirth = DateTime.Parse("27/02/2008"),
               AuthorType = AuthorType.Second,
           },
           new Author("Nash", "Holmes", "Maps")
           {
               Id = Guid.Parse("89BD659C-5AB5-FF4E-F721-C47A72DDB4BB"),
               DateOfBirth = DateTime.Parse("04/05/1997"),
               AuthorType = AuthorType.Second,
           },
           new Author("Rudyard", "Fuller", "General debauchery")
           {
               Id = Guid.Parse("36F18B5C-2B2A-A778-F8C4-43929CAA6AD6"),
               DateOfBirth = DateTime.Parse("29/04/1993"),
               AuthorType = AuthorType.Second,
           },
           new Author("Adam", "Sellers", "Ships")
           {
               Id = Guid.Parse("994B7AB6-1DA9-90AE-B51B-CAFE3CD9A55A"),
               DateOfBirth = DateTime.Parse("22/06/2017"),
               AuthorType = 0,
           },
           new Author("Remedios", "Gould", "Singing")
           {
               Id = Guid.Parse("D4D7A9D4-760C-C710-890E-B90E77CB14B3"),
               DateOfBirth = DateTime.Parse("04/02/2000"),
               AuthorType = 0,
           },
           new Author("Deanna", "Cantrell", "Singing")
           {
               Id = Guid.Parse("72B79E8E-4832-7115-3C6F-05740FA098AF"),
               DateOfBirth = DateTime.Parse("26/08/2004"),
               AuthorType = 0,
           },
           new Author("Jade", "Stout", "Rum")
           {
               Id = Guid.Parse("C8E47237-9FA6-EB11-6A3A-C8BAA5ECA1A1"),
               DateOfBirth = DateTime.Parse("11/10/2002"),
               AuthorType = 0,
           },
           new Author("Ivan", "Bryant", "Rum")
           {
               Id = Guid.Parse("91CBB38A-D32C-19E7-2ABE-205AE0125885"),
               DateOfBirth = DateTime.Parse("04/10/2020"),
               AuthorType = AuthorType.Second,
           },
           new Author("Naida", "Meadows", "Maps")
           {
               Id = Guid.Parse("78AD628E-F62E-1608-D103-5E58F1B062AC"),
               DateOfBirth = DateTime.Parse("07/07/2019"),
               AuthorType = 0,
           },
           new Author("Katelyn", "Mcneil", "General debauchery")
           {
               Id = Guid.Parse("87A9B3C8-63BD-883C-B94E-682053AC798D"),
               DateOfBirth = DateTime.Parse("15/08/2005"),
               AuthorType = AuthorType.Second,
           },
           new Author("Knox", "Underwood", "General debauchery")
           {
               Id = Guid.Parse("E61346EE-BACA-3C52-70EF-266244CE9761"),
               DateOfBirth = DateTime.Parse("08/08/1996"),
               AuthorType = 0,
           },
           new Author("Lester", "Peterson", "Maps")
           {
               Id = Guid.Parse("FDCD869A-9C63-6364-2E95-D421B6AEAB67"),
               DateOfBirth = DateTime.Parse("20/01/2001"),
               AuthorType = 0,
           },
           new Author("Morgan", "Chaney", "Rum")
           {
               Id = Guid.Parse("63DC54B4-D0AE-564A-B534-84A1481CC07B"),
               DateOfBirth = DateTime.Parse("20/09/2000"),
               AuthorType = 0,
           },
           new Author("Keefe", "Howard", "Maps")
           {
               Id = Guid.Parse("6548DDC5-3C3A-C1CF-53E7-512BC71A3368"),
               DateOfBirth = DateTime.Parse("06/02/2005"),
               AuthorType = 0,
           },
           new Author("Talon", "Graves", "General debauchery")
           {
               Id = Guid.Parse("E3F285C0-D443-C37A-5195-1AEADEDFC671"),
               DateOfBirth = DateTime.Parse("04/09/2012"),
               AuthorType = AuthorType.Second,
           },
           new Author("Rylee", "Avila", "Maps")
           {
               Id = Guid.Parse("71C688C6-1DD1-9424-E9E7-4B75B9EA3E2E"),
               DateOfBirth = DateTime.Parse("27/04/2014"),
               AuthorType = AuthorType.Second,
           },
           new Author("Haviva", "Sampson", "Maps")
           {
               Id = Guid.Parse("5411EB51-43A7-82D4-65A5-08121CCCA7A1"),
               DateOfBirth = DateTime.Parse("26/02/2003"),
               AuthorType = AuthorType.Second,
           },
           new Author("Cole", "Case", "General debauchery")
           {
               Id = Guid.Parse("F579582A-1A2B-31CD-AC3D-24C20DC68CFE"),
               DateOfBirth = DateTime.Parse("18/07/1995"),
               AuthorType = AuthorType.Second,
           },
           new Author("Dominic", "Cooke", "General debauchery")
           {
               Id = Guid.Parse("FE2DA4D8-6DCD-AABE-B437-BAB66D0BC751"),
               DateOfBirth = DateTime.Parse("10/02/2020"),
               AuthorType = 0,
           },
           new Author("Illana", "Hoffman", "General debauchery")
           {
               Id = Guid.Parse("39D1D111-5B23-94E7-CB4A-9B87AD1D53EB"),
               DateOfBirth = DateTime.Parse("08/11/1995"),
               AuthorType = AuthorType.Second,
           },
           new Author("Bryar", "Harvey", "General debauchery")
           {
               Id = Guid.Parse("57211422-7ABA-537A-3E8E-31C7C8494BCB"),
               DateOfBirth = DateTime.Parse("06/04/2020"),
               AuthorType = AuthorType.Second,
           },
           new Author("Dexter", "Drake", "Rum")
           {
               Id = Guid.Parse("A50128DB-E4F1-EC83-6C73-5D77229D4A1A"),
               DateOfBirth = DateTime.Parse("30/10/2000"),
               AuthorType = 0,
           },
           new Author("Melyssa", "Conrad", "Singing")
           {
               Id = Guid.Parse("CE417944-D5AE-D6A7-9176-165AD54A271F"),
               DateOfBirth = DateTime.Parse("19/05/2016"),
               AuthorType = 0,
           },
           new Author("Trevor", "Flynn", "Ships")
           {
               Id = Guid.Parse("6505DA8E-8F9E-E4A7-A39C-E72C1CE62DD9"),
               DateOfBirth = DateTime.Parse("19/09/2013"),
               AuthorType = AuthorType.Second,
           },
           new Author("Hedwig", "Frost", "Singing")
           {
               Id = Guid.Parse("9845954B-C531-A143-98BB-245FEE2487C7"),
               DateOfBirth = DateTime.Parse("14/04/2023"),
               AuthorType = 0,
           },
           new Author("Joel", "Mason", "General debauchery")
           {
               Id = Guid.Parse("C79A9DB4-4C4D-B7DA-393F-CE78472664ED"),
               DateOfBirth = DateTime.Parse("17/02/1996"),
               AuthorType = AuthorType.Second,
           },
           new Author("Ivan", "Cleveland", "General debauchery")
           {
               Id = Guid.Parse("6011BCEC-15FA-5018-C99C-A5318F25B943"),
               DateOfBirth = DateTime.Parse("04/03/2024"),
               AuthorType = 0,
           },
           new Author("Chase", "Summers", "Maps")
           {
               Id = Guid.Parse("9579BA12-1F2C-8305-A32A-198E99D1ECEB"),
               DateOfBirth = DateTime.Parse("10/06/1997"),
               AuthorType = AuthorType.Second,
           },
           new Author("Jesse", "Arnold", "Rum")
           {
               Id = Guid.Parse("3F1D5C35-CB46-A21C-1118-D69DD413115A"),
               DateOfBirth = DateTime.Parse("02/08/2021"),
               AuthorType = 0,
           },
           new Author("Mallory", "Ware", "Singing")
           {
               Id = Guid.Parse("4EF56B49-E375-7443-53F7-F2B03295BE70"),
               DateOfBirth = DateTime.Parse("16/06/2008"),
               AuthorType = AuthorType.Second,
           },
           new Author("Abigail", "Boyd", "Singing")
           {
               Id = Guid.Parse("DECB96C0-CA55-8E49-1BA9-D04E5B6397C4"),
               DateOfBirth = DateTime.Parse("05/02/2005"),
               AuthorType = AuthorType.Second,
           },
           new Author("Ahmed", "Tucker", "General debauchery")
           {
               Id = Guid.Parse("8DC610CA-939D-7382-B9AB-3AB8C98A840C"),
               DateOfBirth = DateTime.Parse("03/11/2016"),
               AuthorType = 0,
           },
           new Author("Quinn", "Talley", "Rum")
           {
               Id = Guid.Parse("C56AE8AE-6B84-C441-9F71-F5AA94D0DA6E"),
               DateOfBirth = DateTime.Parse("07/07/1998"),
               AuthorType = AuthorType.Second,
           },
           new Author("Rhona", "Whitehead", "Maps")
           {
               Id = Guid.Parse("E474C335-69AB-2A79-2D14-B5446FEFAD89"),
               DateOfBirth = DateTime.Parse("30/08/2019"),
               AuthorType = AuthorType.Second,
           },
           new Author("Cole", "Stark", "Ships")
           {
               Id = Guid.Parse("298699C6-E24E-30C6-194A-93C5D5954A66"),
               DateOfBirth = DateTime.Parse("29/08/2002"),
               AuthorType = 0,
           },
           new Author("Brian", "Fletcher", "General debauchery")
           {
               Id = Guid.Parse("468F91A8-5AA7-48D7-9A38-A44BFC498984"),
               DateOfBirth = DateTime.Parse("22/07/2021"),
               AuthorType = AuthorType.Second,
           },
           new Author("Eve", "Mcguire", "General debauchery")
           {
               Id = Guid.Parse("19ACC7B2-BEAD-04AF-8397-AFC20854CF72"),
               DateOfBirth = DateTime.Parse("28/10/2009"),
               AuthorType = 0,
           },
           new Author("Russell", "Spencer", "Maps")
           {
               Id = Guid.Parse("8B44C8E5-B8E1-0CE5-FB7B-A06A2D824611"),
               DateOfBirth = DateTime.Parse("05/04/2018"),
               AuthorType = 0,
           },
           new Author("Kato", "Rollins", "General debauchery")
           {
               Id = Guid.Parse("46CDEC61-C642-212B-A43E-14A733446BEA"),
               DateOfBirth = DateTime.Parse("19/09/2017"),
               AuthorType = AuthorType.Second,
           },
           new Author("Haviva", "Chandler", "Singing")
           {
               Id = Guid.Parse("DEF7F1B3-9AD1-2D7B-C459-F64AD53734C3"),
               DateOfBirth = DateTime.Parse("16/01/2022"),
               AuthorType = 0,
           },
           new Author("Stephen", "Schneider", "Rum")
           {
               Id = Guid.Parse("15DB1BD1-5CD9-3D9D-1D1D-95382EC15316"),
               DateOfBirth = DateTime.Parse("19/03/2002"),
               AuthorType = 0,
           },
           new Author("Holly", "Goodwin", "Singing")
           {
               Id = Guid.Parse("33F8AA38-A0EA-5A28-69C5-5CCD5C8488D2"),
               DateOfBirth = DateTime.Parse("12/11/1994"),
               AuthorType = 0,
           },
           new Author("Burke", "Reilly", "Rum")
           {
               Id = Guid.Parse("96D17E7B-3834-22EE-B270-00368DDA521D"),
               DateOfBirth = DateTime.Parse("19/09/1996"),
               AuthorType = 0,
           },
           new Author("Ferris", "Christensen", "Rum")
           {
               Id = Guid.Parse("2ED88741-3FE7-B814-DD30-7722D2E8AC54"),
               DateOfBirth = DateTime.Parse("27/01/2020"),
               AuthorType = 0,
           },
           new Author("Kyra", "Chan", "General debauchery")
           {
               Id = Guid.Parse("DFB5B974-3B37-6C51-C185-D26833D92264"),
               DateOfBirth = DateTime.Parse("20/09/2016"),
               AuthorType = 0,
           },
           new Author("Seth", "Hernandez", "Ships")
           {
               Id = Guid.Parse("AABBCCAC-CE62-645E-4B17-997AD36CED55"),
               DateOfBirth = DateTime.Parse("09/04/1995"),
               AuthorType = AuthorType.Second,
           },
           new Author("Clark", "Barry", "Ships")
           {
               Id = Guid.Parse("110F8BCD-6967-8E64-CD7C-353AE1D5E5ED"),
               DateOfBirth = DateTime.Parse("04/11/1997"),
               AuthorType = AuthorType.Second,
           },
           new Author("Alvin", "Rosa", "Singing")
           {
               Id = Guid.Parse("E9471BA1-352B-82B7-97D7-7E072F2B67B1"),
               DateOfBirth = DateTime.Parse("02/09/1998"),
               AuthorType = 0,
           },
           new Author("Moses", "Gregory", "Ships")
           {
               Id = Guid.Parse("8FD66028-B867-79E7-ADA3-60BD452CF8C1"),
               DateOfBirth = DateTime.Parse("03/08/2011"),
               AuthorType = 0,
           },
           new Author("Madaline", "Mcintosh", "Singing")
           {
               Id = Guid.Parse("DB371ABF-A584-523D-6326-8E345A08C52C"),
               DateOfBirth = DateTime.Parse("27/07/2018"),
               AuthorType = 0,
           },
           new Author("Claudia", "Wooten", "General debauchery")
           {
               Id = Guid.Parse("46A58471-8582-84A0-AEB2-0DB2A5A98466"),
               DateOfBirth = DateTime.Parse("17/02/1996"),
               AuthorType = 0,
           },
           new Author("Marah", "Rivers", "General debauchery")
           {
               Id = Guid.Parse("26A79ADD-3EBC-D9C6-28B5-1A8793278336"),
               DateOfBirth = DateTime.Parse("30/05/2014"),
               AuthorType = AuthorType.Second,
           },
           new Author("Signe", "Perkins", "Rum")
           {
               Id = Guid.Parse("78EC355A-6817-D094-97E6-B2342E9EA551"),
               DateOfBirth = DateTime.Parse("30/05/2009"),
               AuthorType = 0,
           },
           new Author("Quail", "Cabrera", "Ships")
           {
               Id = Guid.Parse("C472FC5E-1469-EEE9-BB89-D84676E88872"),
               DateOfBirth = DateTime.Parse("07/03/1996"),
               AuthorType = AuthorType.Second,
           },
           new Author("Patrick", "Cooper", "General debauchery")
           {
               Id = Guid.Parse("7065CA16-C6DD-4CA3-4E55-71E9BD1B76B8"),
               DateOfBirth = DateTime.Parse("13/02/2020"),
               AuthorType = AuthorType.Second,
           },
           new Author("Chester", "Vaughn", "Maps")
           {
               Id = Guid.Parse("1045A739-64A6-C22E-75DB-EF42A59D1B2D"),
               DateOfBirth = DateTime.Parse("21/08/2014"),
               AuthorType = 0,
           }
);
            modelBuilder.Entity<Course>().HasData(
                   new Course("Commandeering a Ship Without Getting Caught")
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                       AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                       Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
                   },
                   new Course("Overthrowing Mutiny")
                   {
                       Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                       AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                       Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
                   },
                   new Course("Avoiding Brawls While Drinking as Much Rum as You Desire")
                   {
                       Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                       AuthorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                       Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
                   },
                   new Course("Singalong Pirate Hits")
                   {
                       Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                       AuthorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                       Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
                   }
                   );
            // fix to allow sorting on DateTimeOffset when using Sqlite, based on
            // https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                // Sqlite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
                // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
                // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
                // use the DateTimeOffsetToBinaryConverter
                // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754 
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(DateTimeOffset)
                            || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
