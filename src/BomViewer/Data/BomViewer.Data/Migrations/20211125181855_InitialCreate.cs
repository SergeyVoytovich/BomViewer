using Microsoft.EntityFrameworkCore.Migrations;

namespace BomViewer.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "VALVE", null });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 160, null, "A12", "SA-240-410S", "04305-", "BOTTOM RETAINER, 1/4 THK X 44-1/16 OD X 34 ID", "PART" },
                    { 161, null, "B8", "SA-240-410S", "03300-0004", "HEXMESH, 3/4 NO-LANCE (6 SQ.FT)", "PART" },
                    { 162, null, "A9 ", "SA-240-410S", "03200-", "HINGED CORNER PUNCHTAB, 3/4 X 3/4", "PART" },
                    { 163, null, "A10", "C.S.(30%C MAX)", "02101-", "V-ANCHOR, K4.0.7, K4.4.1", "PART" },
                    { 164, null, "B9", "C.S.(30%C MAX)", "02101-", "V-ANCHOR, K4.0.7, K4.4.1", "PART" },
                    { 165, null, "F10a", "SA-240-410S", "04305-", "COVER RETAINER TOP", "PART" },
                    { 166, null, "F10b", "SA-240-410S", "04305-", "COVER RETAINER BOTTOM", "PART" },
                    { 167, null, "F10d", "SA-240-410S", "04305-", "COVER RETAINER, LEFT SIDE", "PART" },
                    { 168, null, "F10c", "SA-240-410S", "04305-", "COVER RETAINER, RIGHT SIDE", "PART" },
                    { 169, null, "F19", "SA-106-GR.B", "20109-1365", "PIPE, 1-SCH.80 X 3 LG", "PART" },
                    { 170, null, "B7", "SA-240-410S", "04305-0006", "RETAINER, 1/4 X 3/4 WD X 109-7/16 LG", "PART" },
                    { 171, null, "X15", "SA-240-410S", "03200-", "PUNCHTAB SPACING STRIP, K4.0.61 X 109-7/16 LG", "PART" },
                    { 172, null, "X13", "RESCO AA-22S", "03400-0016", "REFRACTORY (420 LB)", "PART" },
                    { 173, null, "B2a", "SA-387-GR.11 CL.1 N&T", "09213-", "ORIFICE STUB END", "PART" },
                    { 174, null, "B2a", "SA-387-GR.11 CL.1 N&T", "09213-", "ORIFICE STUB SIDE", "PART" },
                    { 175, null, "A2c1", "SA-387-GR.11 CL.1 N&T", "09213-254878C", "SEAT STUB END", "PART" },
                    { 176, null, "A2c2", "SA-387-GR.11 CL.1 N&T", "04301-", "SEAT STUB SIDE", "PART" },
                    { 177, null, "A13", "SA-105", "20107-", "FLANGE, 2-300# RFWN, SCH.80 BORE", "PART" },
                    { 178, null, "X14", "SA-240-410S", "03300-0004", "HEXMESH, 3/4 NO-LANCE (3 SQ.FT)", "PART" },
                    { 179, null, "X7", "304SS/GRAFOIL", "01302-", "GASKET, SPIRAL WOUND F/ 2-300# RF", "PART" },
                    { 180, null, "X8", "SA-105", "20107-", "BLIND FLANGE, 2-300# RF", "PART" },
                    { 181, null, "N17", "SA-A93-B7", "10004-", "STUD 5/8-11UNC-2A X 3-1/2 LG", "PART" },
                    { 182, null, "N18", "SA-A194-GR.2H", "10005-", "HEX NUT 5/8-11UNC-2B", "PART" },
                    { 183, null, "X10", "304SS/GRAFOIL", "01302-", "GASKET, SPIRAL WOUND F/ 1-300# RF", "PART" },
                    { 184, null, "N15", "SA-A93-B7", "10004-", "STUD 5/8-11UNC-2A X 3-1/4 LG", "PART" },
                    { 159, null, "A11", "SA-240-410S", "04305-", "TOP RETAINER, 1/4 THK X 44 OD X 34 ID", "PART" },
                    { 158, null, "X16", "SA-240-410S", "03200-", "PUNCHTAB, 3/4 X 3/4 X 1 R X 2-3/4 X 2-3/4 K4.0.11", "PART" },
                    { 157, null, "A2e", "SA-240-410S", "04305-", "SEAT RETAINER, 1/4 THK CONE", "PART" },
                    { 156, null, "B9", "SA-240-410S", "03200-", "PUNCHTAB SPACING STRIP, K4.0.61 X 109-7/16 LG", "PART" },
                    { 15, null, "F10 ", "SA-240-410S", "04305-1767", "COVER RETAINER ASSEMBLY", "ASSEMBLY" },
                    { 25, null, "A3d", "SA-516-GR.70N", "09256-", "BONNET SIDE PLATE", "PART" },
                    { 132, null, "A1b", "SA-105", "20107-", "TOP FLANGE", "PART" },
                    { 133, null, "A1d", "SA-105", "20107-", "BOTTOM FLANGE", "PART" },
                    { 134, null, "D8", "SA-387-GR.11 CL.1 N&T", "09003-", "DISC KNUCKLE PLATE", "PART" },
                    { 135, null, "B2", "SA-240-410S", "04305-0006", "RETAINER, 1/4 X 1 WD X 84-3/8 LG", "PART" },
                    { 136, null, "A2g", "SA-240-410S", "04305-0006", "RETAINER, 1/4 X 1 WD X 84-3/8 LG", "PART" },
                    { 137, null, "F10e", "SA-240-410S", "04305-", "COVER RETAINER CORNER PIECE", "PART" },
                    { 138, null, "F21", "SA-105", "20101-", "ELBOW 45 DEG. 1 -3000# S.W.", "PART" },
                    { 139, null, "F20", "SA-105", "20107-", "FLANGE, 1-300# RFWN, SCH.80 BORE", "PART" },
                    { 140, null, "F22", "SA-105", "20101-", "ELBOW 90 DEG. 3/4 -3000# S.W.", "PART" },
                    { 141, null, "F14", "SA-106-GR.B", "20109-1365", "PIPE, 3/4-SCH.80 X 6 LG", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 185, null, "N16", "SA-A194-GR.2H", "10005-", "HEX NUT 5/8-11UNC-2B", "PART" },
                    { 142, null, "F20", "SA-105", "20107-", "FLANGE, 1/2-300# RFWN, SCH.80 BORE", "PART" },
                    { 144, null, "F15", "SA-106-GR.B", "20109-1499", "PIPE, 1-SCH.80 X 6 LG", "PART" },
                    { 145, null, "F7", "SA-106-GR.B", "20109-1365", "PIPE, 1-SCH.80 X 9 LG", "PART" },
                    { 146, null, "F8", "SA-106-GR.B", "20109-1499", "PIPE, 1-SCH.80 X 13-13/16 LG", "PART" },
                    { 147, null, "F12", "SA-240-410S", "03300-", "HEXMESH, 1 LANCE-GRID (8 SQ.FT)", "PART" },
                    { 148, null, "A4 ", "SA-240-410S", "04305-254878", "BONNET RETAINER", "PART" },
                    { 149, null, "M2", "304SS/GRAFOIL", "04312-254878", "BONNET GASKET", "PART" },
                    { 150, null, "X9", "SA-105", "20107-", "BLIND FLANGE, 1-300# RF", "PART" },
                    { 151, null, "F23", "SA-105", "20107-", "FLANGE, 1-300# RFWN SCH.80 BORE", "PART" },
                    { 152, null, "A8 ", "SA-240-410S", "03300-", "HEXMESH, 1 LANCE-GRID (90 SQ.FT)", "PART" },
                    { 153, null, "X17", "SA-240-410S", "04305-0006", "RETAINER, 1/4 X 3/4 WD X 116-9/16 LG", "PART" },
                    { 154, null, "A2d", "SA-387-GR.11 CL.1 N&T", "04301-", "SEAT STUB PLATE", "PART" },
                    { 155, null, "B4", "SA-240-410S", "03200-0309", "PUNCHTAB, 3/4 X 3/4 X 1 R X 2-3/4 X 2-3/4 K4.0.11", "PART" },
                    { 143, null, "F22", "SA-105", "20101-", "ELBOW 90 DEG. 1 -3000# S.W.", "PART" },
                    { 186, null, "A16", "SA-105", "20107-", "FLANGE, 1-300# RFWN, SCH.80 BORE", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, "BODY", 1 },
                    { 25, "NUT_N14", 1 },
                    { 26, "SPRING_WASH", 1 },
                    { 27, "STUD_N1", 1 },
                    { 28, "NUT_N2", 1 },
                    { 29, "BOLT_N4", 1 },
                    { 30, "BOLT_N3", 1 },
                    { 31, "BOLT_N5", 1 },
                    { 32, "STUD_N6", 1 },
                    { 33, "STUD_N8", 1 },
                    { 34, "NUT_N7", 1 },
                    { 35, "WARN_TAG_PURGE", 1 },
                    { 36, "WARN_TAG_SEAL", 1 },
                    { 37, "DOWEL_COVFLG", 1 },
                    { 38, "ACTUATOR", 1 },
                    { 39, "NULL_ANCHORS", 1 },
                    { 40, "PIPEPLUG200", 1 },
                    { 41, "BOLT_ACT", 1 },
                    { 24, "BOLT_N13", 1 },
                    { 23, "BOLT_X5", 1 },
                    { 22, "BOLT_GASKET", 1 },
                    { 21, "PKG_GLAND", 1 },
                    { 3, "ORIFICE_GASKET", 1 },
                    { 4, "ORIFICE", 1 },
                    { 5, "DISC", 1 },
                    { 6, "GUIDE_SET", 1 },
                    { 7, "STEM", 1 },
                    { 8, "COV_FLG", 1 },
                    { 9, "FOLLOW_FLG", 1 },
                    { 10, "SBP_PIPEPLUG", 1 },
                    { 42, "NUT_ACT", 1 },
                    { 11, "SBS_PIPEPLUG", 1 },
                    { 13, "DRIVESCREW", 1 },
                    { 14, "NULL_LIPSEAL", 1 },
                    { 15, "PACKING_F4", 1 },
                    { 16, "PACKING_F3", 1 },
                    { 17, "SLEEVE", 1 },
                    { 18, "PACKING_F2", 1 },
                    { 19, "LANT_RING", 1 },
                    { 20, "SEP_RING", 1 },
                    { 12, "NAMEPLATE", 1 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[] { 1, 1, "?", "?", "00001-254878", "VALVE ASSEMBLY", "ASSEMBLY" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 43, "BODY_SPOOL", 2 },
                    { 164, "GP_VALVE", 8 },
                    { 163, "WELD_GP", 8 },
                    { 162, "GP_JPAPER", 8 },
                    { 161, "GP_PIPE_IS", 8 },
                    { 160, "GP_PIPE_OS", 8 },
                    { 159, "COV_REFY", 8 },
                    { 158, "COV_RETAINER", 8 },
                    { 157, "WELD_LIPSEAL", 8 },
                    { 156, "LIPSEAL", 8 },
                    { 155, "WELD_SBOX_BACKSEAT", 8 },
                    { 154, "WELD_SBOX", 8 },
                    { 165, "LIFT_LUG_COVER", 8 },
                    { 153, "WELD_SBOX_EAR", 8 },
                    { 150, "SBOX_INNER", 8 },
                    { 149, "SBOX_OUTER", 8 },
                    { 148, "COV_FLG_PL", 8 },
                    { 147, "WELD_STEM_HF", 7 },
                    { 146, "STEM_FORG", 7 },
                    { 139, "GUIDE_RH", 6 },
                    { 138, "GUIDE_LH", 6 },
                    { 137, "DISC_MTO_PL", 5 },
                    { 136, "DISC_BOT_PTAB_STRIP", 5 },
                    { 135, "DISC_TOP_PTAB_STRIP", 5 },
                    { 134, "DISC_HEXMESH", 5 },
                    { 151, "WELD_SBOXES", 8 },
                    { 166, "WELD_LUG_COV", 8 },
                    { 167, "SBP_CPLG_T", 8 },
                    { 168, "SBP_CPLG_B", 8 },
                    { 196, "V_ANC_COV_CAP", 39 },
                    { 195, "V_ANC_COV_V1", 39 },
                    { 194, "V_ANC_BOD_CAP", 39 },
                    { 193, "V_ANC_BOD_V7", 39 },
                    { 192, "V_ANC_BOD_V6", 39 },
                    { 191, "V_ANC_BOD_V5", 39 },
                    { 190, "V_ANC_BOD_V4", 39 },
                    { 189, "V_ANC_BOD_V3", 39 },
                    { 188, "V_ANC_BOD_V2", 39 },
                    { 187, "V_ANC_BOD_V1", 39 },
                    { 186, "BLAC_ACTUATOR", 38 },
                    { 182, "PIPE_BRACE3", 8 },
                    { 181, "PIPE_BRACE4", 8 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 180, "PIPE_BRACE1", 8 },
                    { 179, "ADAPT_YOKE", 8 },
                    { 178, "COV_REFY_NEEDLES", 8 },
                    { 177, "COV_JPAPER", 8 },
                    { 176, "SBS_VALVE", 8 },
                    { 175, "SBS_PIPE_T", 8 },
                    { 174, "SBP_VALVE", 8 },
                    { 173, "SBP_PIPE_T", 8 },
                    { 172, "WELD_SBS_CPLG", 8 },
                    { 171, "WELD_SBP_CPLG", 8 },
                    { 170, "SBS_CPLG_B", 8 },
                    { 169, "SBS_CPLG_T", 8 },
                    { 133, "DISC_BOT_PTAB", 5 },
                    { 132, "DISC_TOP_PTAB", 5 },
                    { 152, "SBOX_EAR", 8 },
                    { 130, "WELD_DISC_HF", 5 },
                    { 70, "WELD_SPOOL_LS", 2 },
                    { 69, "WELD_BON2BODB", 2 },
                    { 68, "WELD_BON2BODT", 2 },
                    { 67, "WELD_BON2BODL", 2 },
                    { 66, "WELD_BON2BODR", 2 },
                    { 65, "WELD_NP_BRKT", 2 },
                    { 64, "NAMEPLATE_BRKT", 2 },
                    { 63, "WELD_LUG_BOD_R", 2 },
                    { 62, "LIFT_LUG_BODY", 2 },
                    { 61, "FORM_BODY", 2 },
                    { 60, "FORM_TOP", 2 },
                    { 59, "BON_RET_ASSY", 2 },
                    { 58, "WELD_SEATCONE", 2 },
                    { 57, "BODY_REFYTOP", 2 },
                    { 131, "DISC_REFY", 5 },
                    { 55, "WELD_LIPSEAL", 2 },
                    { 54, "LIPSEAL", 2 },
                    { 53, "SEAT", 2 },
                    { 52, "WELD_TOPCONE_TOP", 2 },
                    { 51, "WELD_BOTCONE_BOT", 2 },
                    { 50, "BONNET", 2 },
                    { 49, "BOT_STUB", 2 },
                    { 48, "WELD_BOTCONE2SPOOL", 2 },
                    { 47, "BOT_CONE", 2 },
                    { 46, "TOP_STUB", 2 },
                    { 45, "WELD_TOPCONE2SPOOL", 2 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 44, "TOP_CONE", 2 },
                    { 71, "KAOWOOL", 2 },
                    { 72, "CONE_CARDBOARD", 2 },
                    { 56, "BODY_REFY", 2 },
                    { 74, "BODY_REFY_NEEDLES", 2 },
                    { 73, "BODY_JPAPER", 2 },
                    { 124, "ORIFICE_PL", 4 },
                    { 125, "OPLT_RETAINER_BOT", 4 },
                    { 126, "OPLT_REFY", 4 },
                    { 127, "ORIFICE_PTAB", 4 },
                    { 129, "DISC_PL", 5 },
                    { 88, "BON_VALVE", 2 },
                    { 87, "JACK_VALVE", 2 },
                    { 86, "JACKING_BRKT", 2 },
                    { 85, "JACKING_FLG", 2 },
                    { 128, "OPLT_PTAB_STRIP", 4 },
                    { 84, "PIPE_BRACE2", 2 },
                    { 83, "WELD_BP", 2 },
                    { 82, "BP_KAOWOOL", 2 },
                    { 81, "BP_PIPE_IS", 2 },
                    { 80, "BP_PIPE_OS", 2 },
                    { 79, "WELD_JK_PORT", 2 },
                    { 78, "JK_KAOWOOL", 2 },
                    { 77, "JK_PIPE_IS", 2 },
                    { 76, "JK_PIPE_OS", 2 },
                    { 75, "CARDBOARD", 2 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 112, 31, "N5", "SA-453-GR.660C", "10008-2373", "H.H.C.S. 1-8UNC-2A X 4-3/4 LG", "PART" },
                    { 113, 32, "N6", "SA-A93-B7", "10004-0765", "STUD 3/4-10UNC-2A X 7 LG", "PART" },
                    { 114, 33, "N6", "SA-A93-B7", "10004-0765", "STUD 3/4-10UNC-2A X 7 LG", "PART" },
                    { 115, 34, "N7", "SA-A194-GR.2H", "10005-0030", "HEX NUT 3/4-10UNC-2B", "PART" },
                    { 116, 35, "X11", "SS", "04314-0003", "WARNING TAG FOR PURGE CONNECTION", "PART" },
                    { 117, 36, "X12", "SS", "04314-0004", "WARNING TAG FOR SEALANT CONNECTION", "PART" },
                    { 8, 6, "C", "SA-387-GR.11 CL.1 N&T", "09521-254878", "GUIDE SET (LH AND RH)", "ASSEMBLY" },
                    { 2, 2, "A", "SA-516-GR.70N", "09200-254878", "BODY ASSEMBLY", "ASSEMBLY" },
                    { 14, 38, "H", "BLAC INC.", "08714-254878", "ACTUATOR", "ASSEMBLY" },
                    { 52, 3, "M1", "316SS/GRAFOIL", "01303-254878", "ORIFICE GASKET, METAL REINFORCED LAMINATE STYLE GHE\"\"", "PART" },
                    { 129, 40, "X8", "SA-105", "10002-0048", "PIPE PLUG 2 NPT", "PART" },
                    { 7, 5, "D", "SA-387-GR.11 CL.1 N&T", "09000-254878", "DISC ASSEMBLY", "ASSEMBLY" },
                    { 111, 30, "N3", "SA-453-GR.660C", "10008-2363", "H.H.C.S. 1-8UNC-2A X 2-1/4 LG", "PART" },
                    { 6, 4, "B", "SA-387-GR.11 CL.1 N&T", "09501-254878", "ORIFICE PLATE ASSEMBLY", "ASSEMBLY" },
                    { 118, 37, "N10", "AISI 4140", "04334-0037", "DOWEL PIN, 1/2 DIA X 1 3/4 LG (BODY/COVER FLG)", "PART" },
                    { 110, 29, "N4", "SA-453-GR.660C", "10008-2381", "H.H.C.S. 1-8UNC-2A X 6-3/4 LG", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 102, 21, "W", "SA-479-304H", "09310-0166", "PACKING GLAND", "PART" },
                    { 108, 27, "N1", "SA-453-GR.660C", "10004-2880", "STUD 1-8UNC-2A X 3-1/2 LG", "PART" },
                    { 130, 41, "N8", "SA-193-B7", "10008-2278", "H.H.C.S. 1-1/8-8UN-2A X 4-1/2 LG", "PART" },
                    { 11, 7, "E", "SA-182-F316H", "09713-254878", "LOWER STEM W/WALLEX #50", "ASSEMBLY" },
                    { 12, 8, "F", "SA-516-GR.70N", "09327-254878", "COVER FLANGE/STUFFING BOX ASSY", "ASSEMBLY" },
                    { 90, 9, "U", "SA-240-304/304H", "09311-0201", "FOLLOWING FLANGE", "PART" },
                    { 91, 10, "X6", "SA-105", "10002-0028", "PIPE PLUG, 1 NPT", "PART" },
                    { 92, 11, "X7", "SA-105", "10002-0008", "PIPE PLUG, 1/2 NPT", "PART" },
                    { 93, 12, "NP", "SS", "04314-254878", "NAMEPLATE", "PART" },
                    { 94, 13, "NPS", "SS", "10012-0034", "METALLIC DRIVE SCREW, #8 U x 3/8 LG", "PART" },
                    { 95, 14, "M2", "SA-516-GR.70", "04312-254878", "LIPSEAL", "PART" },
                    { 109, 28, "N2", "SA-453-GR.660C", "10005-0043", "HEX NUT 1-8UNC-2B", "PART" },
                    { 96, 15, "F4", "CHESTERTON #1601", "09312-0339", "PACKING RING 1/2 SQ X 9-7/16 LG", "PART" },
                    { 98, 17, "R", "ANNEALED NITRONIC #60", "09307-0561", "SLEEVE", "PART" },
                    { 99, 18, "F2", "CHESTERTON STYLE 1", "09312-0156", "PACKING RING 1/2 SQ X 9-7/16 LG", "PART" },
                    { 100, 19, "T", "SA-479-304H", "09308-0191", "LANTERN RING", "PART" },
                    { 101, 20, "S", "SA-479-304H", "09309-0154", "SEPARATION BAFFLE RING", "PART" },
                    { 103, 22, "X4", "304SS/GRAFOIL", "04301-4514", "GASKET F/ 1/2 CAPSCREW\"", "PART" },
                    { 104, 23, "X5", "SA-193-B8", "10026-0132", "H.H.BOLT 1/2-13UNC-2A X 1-1/8 LG", "PART" },
                    { 105, 24, "N13", "SA-193-B8", "10026-0225", "H.H.BOLT 3/4-10UNC-2A X 7 LG  (ALL THREAD)", "PART" },
                    { 106, 25, "N14", "SA-194-GR.8", "10005-0031", "HEX NUT 3/4-10UNC-2B", "PART" },
                    { 107, 26, "X1", "SPRING STEEL", "04301-1869", "SPRING WASHERS", "PART" },
                    { 97, 16, "F3", "CHESTERTON #5300", "09312-0399", "PACKING RING 1/2 SQ X 2 ID X 3 OD", "PART" },
                    { 131, 42, "N9", "SA-194-GR.2H", "10005-0051", "HEX NUT 1-1/8-8UN-2B", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 112, "FORM_SPOOL_ASSY", 61 },
                    { 105, "SEAT_PTAB", 53 },
                    { 106, "SEAT_PTAB_STRIP", 53 },
                    { 107, "SEAT_REFY", 53 },
                    { 108, "BON_RET_TOP", 59 },
                    { 109, "BON_RET_BOT", 59 },
                    { 110, "BON_RET_RSIDE", 59 },
                    { 111, "BON_RET_LSIDE", 59 },
                    { 104, "WELD_SEAT2SUPPORT", 53 },
                    { 144, "WELD_HF_GUIDE_RH", 139 },
                    { 185, "WELD_YOKE_2", 179 },
                    { 184, "YOKE_SIDEPLATE_C", 179 },
                    { 183, "ADAPT_FLNG_ACTSIDE", 179 },
                    { 140, "GUIDE_LH_PL", 138 },
                    { 141, "WELD_HF_GUIDE_LH", 138 },
                    { 142, "GUIDE_MTO_LH", 138 },
                    { 143, "GUIDE_RH_PL", 139 },
                    { 113, "FORM_BON_ASSY", 61 },
                    { 103, "WELD_SEATCONES", 53 },
                    { 145, "GUIDE_MTO_RH", 139 },
                    { 101, "SEAT_BOT_CONE", 53 },
                    { 102, "SEAT_TOP_CONE", 53 },
                    { 89, "BON_FLG", 50 },
                    { 90, "BON_TOP_PL", 50 },
                    { 91, "BON_BOT_PL", 50 },
                    { 93, "WELD_LUG_BOD_F", 50 },
                    { 94, "WELD_BON_LSR", 50 },
                    { 95, "WELD_BON_LSL", 50 },
                    { 96, "WELD_BON2FLGBOT", 50 },
                    { 92, "LIFT_LUG_BODY", 50 },
                    { 98, "SEAT_PL", 53 },
                    { 100, "WELD_SEATSTUB2CONE", 53 },
                    { 99, "SEAT_STUB", 53 },
                    { 97, "WELD_BON2FLG", 50 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 73, 164, "F23", "SA-105/13Cr TRIM/HF SEATS", "20103-0273", "GATE VALVE, 1-800# S.W. X S.W. FULL PORT, VOGT SW13111 OR EQ.", "PART" },
                    { 72, 161, "F17", "SA-335-P11", "20109-0176", "PIPE, 1-SCH.80 X 4 LG", "PART" },
                    { 71, 160, "F18", "SA-106-GR.B", "20109-1365", "PIPE, 1-SCH.80 X 7-1/2 LG", "PART" },
                    { 70, 159, "F11", "RESCOCAST 110C", "03500-0055", "INSULATING REFRACTORY (393 LB)", "PART" },
                    { 69, 158, "F10", "SA-240-410S", "04305-1767", "RETAINER, 1/4 X 5 WD X 130-1/16 LG", "PART" },
                    { 68, 152, "F6", "SA-516-GR.70N", "09304-0032", "STUFFING BOX EAR K4.10.2", "PART" },
                    { 124, 192, "V6", "C.S.(30%C MAX)", "02101-1299", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 67, 150, "F3", "SA-182-F11", "09303-254878A", "STUFFING BOX BARREL, INNER", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 66, 149, "F2", "SA-350-LF2", "09303-254878B", "STUFFING BOX BARREL, OUTER", "PART" },
                    { 65, 148, "F1", "SA-516-GR.70N", "09302-254878", "COVER FLANGE PLATE", "PART" },
                    { 74, 165, "F16", "SA-516-GR.70N", "04303-0037", "LIFTING LUG, K4.11.0", "PART" },
                    { 10, 139, "C2", "SA-387-GR.11 CL.1 N&T", "09509-254878", "RH GUIDE", "ASSEMBLY" },
                    { 123, 191, "V5", "C.S.(30%C MAX)", "02101-1298", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 125, 193, "V7", "C.S.(30%C MAX)", "02101-1300", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 126, 194, "V8 ", "PLASTIC", "04301-3921", "PLASTIC END CAP F/ V-ANCHOR, 1/4 DIA", "PART" },
                    { 75, 167, "F5", "SA-105", "04313-0091", "HALF COUPLING, 1 SW 3000#", "PART" },
                    { 82, 176, "F9", "SA-105/13Cr TRIM/HF SEATS", "20103-0313", "GATE VALVE, 1/2 -800# S.W. X S.W.", "PART" },
                    { 77, 169, "F5", "SA-105", "04313-0079", "HALF COUPLING, 1/2 SW 3000#", "PART" },
                    { 122, 190, "V4", "C.S.(30%C MAX)", "02101-1297", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 121, 189, "V3", "C.S.(30%C MAX)", "02101-1296", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 120, 188, "V2", "C.S.(30%C MAX)", "02101-1295", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 119, 187, "V1", "C.S.(30%C MAX)", "02101-1294", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 89, 182, "F20", "SA-36", "04301-254878C", "FLAT BAR, 3/16 X 3/4\" X 7-7/16\" LG\"", "PART" },
                    { 88, 181, "F21", "SA-36", "04301-254878C", "FLAT BAR, 3/16 X 3/4\" X 9-13/16\" LG\"", "PART" },
                    { 76, 168, "F4", "SA-105", "04313-0076", "HALF COUPLING, 1 NPT 3000#", "PART" },
                    { 87, 180, "F19", "SA-36", "04301-254878C", "FLAT BAR, 3/16 X 3/4\" X 6-3/8\" LG\"", "PART" },
                    { 84, 178, "F12", "304SS", "03500-2012", "NEEDLES, .020 DIA X 1 LG MELT EXTRACTED (8 LB)", "PART" },
                    { 83, 177, "F15", "FIBERFRAX", "03500-3000", "J-PAPER, 1/8 THK (5 SQ.FT)", "PART" },
                    { 81, 175, "F8", "SA-106-GR.B", "20109-1499", "PIPE, 1/2-SCH.80 X 14-1/4 LG", "PART" },
                    { 80, 174, "F9", "SA-105/13Cr TRIM/HF SEATS", "20103-0272", "GATE VALVE, 1 -800# S.W. X S.W.", "PART" },
                    { 79, 173, "F7", "SA-106-GR.B", "20109-1365", "PIPE, 1-SCH.80 X 7-7/8 LG", "PART" },
                    { 78, 170, "F4", "SA-105", "04313-0006", "HALF COUPLING, 1/2 NPT 3000#", "PART" },
                    { 13, 179, "G", "SA-36", "09801-254878", "ADAPTER YOKE ASS'Y F/DOUBLE LEAD SCREW ACTUATOR", "ASSEMBLY" },
                    { 16, 43, "A1 ", "SA-516-GR.70N", "09204-254878", "BODY SPOOL", "PART" },
                    { 56, 127, "B4", "SA-240-410S", "03200-0077", "PUNCHTAB, 1 X 1 X 1 R X 3 X 3 K4.0.15", "PART" },
                    { 64, 136, "D5", "SA-240-410S", "03200-0317", "PUNCHTAB SPACING STRIP, K4.0.62 X 25-5/8 LG", "PART" },
                    { 43, 76, "A14", "SA-106-GR.B", "20109-0133", "PIPE, 2-SCH.80 X 9-5/8 LG", "PART" },
                    { 42, 75, "CB ", "CARDBOARD", "03500-0013", "CARDBOARD, 3/16 THK X 24 WD X 36 LG", "PART" },
                    { 41, 74, "A8 ", "304SS", "03500-2012", "NEEDLES, .020 DIA X 1 LG MELT EXTRACTED (99 LB)", "PART" },
                    { 40, 73, "A9 ", "FIBERFRAX", "03500-3000", "J-PAPER, 1/8 THK (6 SQ.FT)", "PART" },
                    { 39, 64, "A5 ", "SA-516-GR.70N", "04315-0024", "NAMEPLATE BRACKET, K4.12.1", "PART" },
                    { 24, 62, "A6 ", "SA-516-GR.70N", "04303-0037", "LIFTING LUG, K4.11", "PART" },
                    { 5, 59, "A4 ", "SA-240-410S", "04305-254878", "BONNET RETAINER ASSEMBLY", "ASSEMBLY" },
                    { 34, 56, "A7 ", "RESCOCAST 110C", "03500-0055", "INSULATING REFRACTORY (4950 LB)", "PART" },
                    { 33, 54, "M2", "SA-516-GR.70", "04312-254878", "LIPSEAL", "PART" },
                    { 4, 53, "A2 ", "SA-387-GR.11 CL.1 N&T", "09237-254878", "SEAT ASSEMBLY", "ASSEMBLY" },
                    { 3, 50, "A3 ", "SA-516-GR.70N", "09262-254878", "BONNET ASSEMBLY", "ASSEMBLY" },
                    { 20, 49, "A1d", "SA-516-GR.70N", "09213-254878B", "BOTTOM STUB", "PART" },
                    { 19, 47, "A1c", "SA-516-GR.70N", "09209-254878B", "BOTTOM CONE", "PART" },
                    { 18, 46, "A1b", "SA-516-GR.70N", "09213-254878A", "TOP STUB", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 17, 44, "A1a", "SA-516-GR.70N", "09209-254878A", "TOP CONE", "PART" },
                    { 44, 77, "A15", "SA-312-TP304H", "20109-0108", "PIPE, 2-SCH.80 X 4 LG", "PART" },
                    { 9, 138, "C1", "SA-387-GR.11 CL.1 N&T", "09508-254878", "LH GUIDE", "ASSEMBLY" },
                    { 45, 80, "A17", "SA-106-GR.B", "20109-0040", "PIPE, 1-SCH.80 X 6-7/8 LG", "PART" },
                    { 47, 84, "A13", "SA-36", "04301-254878C", "FLAT BAR, 3/16 X 3/4\" X 4-1/4\" LG\"", "PART" },
                    { 63, 135, "D4", "SA-240-410S", "03200-0309", "PUNCHTAB SPACING STRIP, K4.0.60 X 26-1/4 LG", "PART" },
                    { 62, 134, "D6", "SA-240-410S", "03300-0004", "HEXMESH, 1 LANCE-GRID (7 SQ.FT)", "PART" },
                    { 61, 133, "D3", "SA-240-410S", "03200-0079", "PUNCHTAB, 1 X 1 X 1/4 R X 3 X 3 K4.0.14", "PART" },
                    { 60, 132, "D2", "SA-240-410S", "03200-0077", "PUNCHTAB, 1 X 1 X 1 R X 3 X 3 K4.0.15", "PART" },
                    { 59, 131, "D7", "RESCO AA-22S", "03400-0016", "REFRACTORY (117 LB)", "PART" },
                    { 58, 129, "D1", "SA-387-GR.11 CL.1 N&T", "09002-254878", "DISC PLATE", "PART" },
                    { 57, 128, "B5", "SA-240-410S", "03200-0309", "PUNCHTAB SPACING STRIP, K4.0.60 X 84-3/8 LG", "PART" },
                    { 127, 195, "V1", "C.S.(30%C MAX)", "02101-1294", "V-ANCHORS (SEE A-SIZE DWG 02101-254878)", "PART" },
                    { 55, 126, "B6", "RESCO AA-22S", "03400-0016", "REFRACTORY (39 LB)", "PART" },
                    { 54, 125, "B3", "SA-240-410S", "04305-0006", "RETAINER, 1/4 X 1 WD X 97-3/4 LG", "PART" },
                    { 53, 124, "B1", "SA-387-GR.11 CL.1 N&T", "09503-254878", "ORIFICE PLATE", "PART" },
                    { 51, 88, "A19", "SA-105/13Cr TRIM/HF SEATS", "20103-0273", "GATE VALVE, 1-800# S.W. X S.W. FULL PORT, VOGT SW13111 OR EQ.", "PART" },
                    { 50, 87, "A16", "SA-105/13Cr TRIM/HF SEATS", "20103-0260", "GATE VALVE, 2-800# NPT X S.W. FULL PORT, VOGT 143111 OR EQ.", "PART" },
                    { 49, 86, "A11", "SA-36", "50036-0500", "PLATE, 1/2 X 7-7/16\" X 9\"\"", "PART" },
                    { 48, 85, "A10", "SA-36", "50036-0500", "PLATE, 1/2 THK X 10\" X 10\"\"", "PART" },
                    { 46, 81, "A18", "SA-312-TP304H", "20109-0059", "PIPE, 1-SCH.80 X 4 LG", "PART" },
                    { 128, 196, "V2", "PLASTIC", "04301-3921", "PLASTIC END CAP F/ V-ANCHOR, 1/4 DIA", "PART" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 123, "FORM_NUT2", 113 },
                    { 122, "FORM_BOLT2", 113 },
                    { 121, "FORM_BON_TOP", 113 },
                    { 120, "FORM_BON_R_SPC", 113 },
                    { 119, "FORM_BON_L_SPC", 113 },
                    { 118, "FORM_BON_BOT", 113 },
                    { 117, "FORM_RING_BOT", 112 },
                    { 116, "FORM_RING_SPL", 112 },
                    { 115, "FORM_RING_TOP", 112 },
                    { 114, "FORM_SPOOL", 112 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "GroupId", "Item", "Material", "Number", "Title", "Type" },
                values: new object[,]
                {
                    { 21, 89, "A3c", "SA-516-GR.70N", "09201-254878", "BONNET FLANGE", "PART" },
                    { 38, 111, "A4c", "SA-240-410S", "04305-254878C", "BONNET RETAINER, SIDE", "PART" },
                    { 37, 110, "A4c", "SA-240-410S", "04305-254878C", "BONNET RETAINER, SIDE", "PART" },
                    { 36, 109, "A4b", "SA-240-410S", "04305-254878B", "BONNET RETAINER, BOTTOM", "PART" },
                    { 35, 108, "A4a", "SA-240-410S", "04305-254878A", "BONNET RETAINER, TOP", "PART" },
                    { 32, 107, "A2f", "RESCO AA-22S", "03400-0016", "REFRACTORY (19 LB)", "PART" },
                    { 31, 106, "A2e", "SA-240-410S", "03200-0317", "PUNCHTAB SPACING STRIP, K4.0.62 X 84-3/8 LG", "PART" },
                    { 30, 105, "A2d", "SA-240-410S", "03200-0296", "PUNCHTAB, 1 X 1 X SQ X 3 X 3 K4.0.31", "PART" },
                    { 29, 102, "A2h", "SA-516-GR.70N", "09233-254878B", "UPPER SEAT CONE", "PART" },
                    { 28, 101, "A2b", "SA-387-GR.11 CL.1 N&T", "09233-254878A", "SEAT CONE", "PART" },
                    { 27, 99, "A2c", "SA-387-GR.11 CL.1 N&T", "09213-254878C", "SEAT STUB", "PART" },
                    { 26, 98, "A2a", "SA-387-GR.11 CL.1 N&T", "09205-254878", "SEAT PLATE", "PART" },
                    { 23, 91, "A3a", "SA-516-GR.70N", "09256-254878A", "BONNET BOTTOM PLATE", "PART" },
                    { 22, 90, "A3b", "SA-516-GR.70N", "09256-254878B", "BONNET TOP PLATE", "PART" },
                    { 85, 183, "G1", "SA-36", "09802-254878", "YOKE ADAPTER FLANGE, 1-1/4 X 18 X 21-1/2", "PART" },
                    { 86, 184, "G2", "SA-36", "09807-0621", "SIDE CHANNELS, MC13 X 50# X 22 LG\"", "PART" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_GroupId",
                table: "Parts",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
