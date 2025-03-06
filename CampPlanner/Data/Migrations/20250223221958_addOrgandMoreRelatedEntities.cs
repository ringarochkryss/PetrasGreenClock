using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampPlanner.Migrations
{
    /// <inheritdoc />
    public partial class addOrgandMoreRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventParticipantRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipantRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnitureIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBed = table.Column<bool>(type: "bit", nullable: false),
                    IsDesk = table.Column<bool>(type: "bit", nullable: false),
                    IsSeat = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logotype = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherApiCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    HasShower = table.Column<bool>(type: "bit", nullable: false),
                    HasFridge = table.Column<bool>(type: "bit", nullable: false),
                    HasFreezer = table.Column<bool>(type: "bit", nullable: false),
                    HasWashingMachine = table.Column<bool>(type: "bit", nullable: false),
                    HasDishwasher = table.Column<bool>(type: "bit", nullable: false),
                    HasKitchen = table.Column<bool>(type: "bit", nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    WifiCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    NumberOfDesks = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    IsHandicapAccessible = table.Column<bool>(type: "bit", nullable: false),
                    AllowsDogs = table.Column<bool>(type: "bit", nullable: false),
                    AllowsSmoking = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    EventImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisibleForAll = table.Column<bool>(type: "bit", nullable: false),
                    BookingEventPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingForParticipantsAllowedEvent = table.Column<bool>(type: "bit", nullable: false),
                    BookingForParticipantsAllowedRooms = table.Column<bool>(type: "bit", nullable: false),
                    BookingForParticipantsAllowedAppointments = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationFeature_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeFrom = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeTo = table.Column<TimeSpan>(type: "time", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    VisibleForAll = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarView_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    IsHandicapAccessible = table.Column<bool>(type: "bit", nullable: false),
                    AllowsDogs = table.Column<bool>(type: "bit", nullable: false),
                    AllowsSmoking = table.Column<bool>(type: "bit", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    HasShower = table.Column<bool>(type: "bit", nullable: false),
                    IsMeetingRoom = table.Column<bool>(type: "bit", nullable: false),
                    IsWorkspace = table.Column<bool>(type: "bit", nullable: false),
                    IsBedroom = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Room_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furniture_FurnitureType_FurnitureTypeId",
                        column: x => x.FurnitureTypeId,
                        principalTable: "FurnitureType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furniture_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsMainParticipant = table.Column<bool>(type: "bit", nullable: false),
                    RoomRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FurnitureRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    FurnitureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingParticipant_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingParticipant_Furniture_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furniture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingParticipant_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingParticipant_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FurnitureReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FurnitureReservation_Furniture_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureReservation_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    BookingParticipantId = table.Column<int>(type: "int", nullable: false),
                    EventParticipantRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentRole_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentRole_BookingParticipant_BookingParticipantId",
                        column: x => x.BookingParticipantId,
                        principalTable: "BookingParticipant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentRole_EventParticipantRole_EventParticipantRoleId",
                        column: x => x.EventParticipantRoleId,
                        principalTable: "EventParticipantRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingParticipantRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingParticipantId = table.Column<int>(type: "int", nullable: false),
                    EventParticipantRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingParticipantRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingParticipantRole_BookingParticipant_BookingParticipantId",
                        column: x => x.BookingParticipantId,
                        principalTable: "BookingParticipant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingParticipantRole_EventParticipantRole_EventParticipantRoleId",
                        column: x => x.EventParticipantRoleId,
                        principalTable: "EventParticipantRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarViewId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    BookingParticipantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarRow_BookingParticipant_BookingParticipantId",
                        column: x => x.BookingParticipantId,
                        principalTable: "BookingParticipant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarRow_CalendarView_CalendarViewId",
                        column: x => x.CalendarViewId,
                        principalTable: "CalendarView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarRow_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarRowId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarAppointment_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarAppointment_CalendarRow_CalendarRowId",
                        column: x => x.CalendarRowId,
                        principalTable: "CalendarRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_EventId",
                table: "Appointment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRole_AppointmentId",
                table: "AppointmentRole",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRole_BookingParticipantId",
                table: "AppointmentRole",
                column: "BookingParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentRole_EventParticipantRoleId",
                table: "AppointmentRole",
                column: "EventParticipantRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_EventId",
                table: "Booking",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipant_BookingId",
                table: "BookingParticipant",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipant_FurnitureId",
                table: "BookingParticipant",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipant_PersonId",
                table: "BookingParticipant",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipant_RoomId",
                table: "BookingParticipant",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipantRole_BookingParticipantId",
                table: "BookingParticipantRole",
                column: "BookingParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingParticipantRole_EventParticipantRoleId",
                table: "BookingParticipantRole",
                column: "EventParticipantRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_LocationId",
                table: "Building",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarAppointment_AppointmentId",
                table: "CalendarAppointment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarAppointment_CalendarRowId",
                table: "CalendarAppointment",
                column: "CalendarRowId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_BookingParticipantId",
                table: "CalendarRow",
                column: "BookingParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_CalendarViewId",
                table: "CalendarRow",
                column: "CalendarViewId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_RoomId",
                table: "CalendarRow",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarView_EventId",
                table: "CalendarView",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizationId",
                table: "Event",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_FurnitureTypeId",
                table: "Furniture",
                column: "FurnitureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_RoomId",
                table: "Furniture",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureReservation_FurnitureId",
                table: "FurnitureReservation",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureReservation_PersonId",
                table: "FurnitureReservation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationId",
                table: "Location",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFeature_LocationId",
                table: "LocationFeature",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_AppointmentId",
                table: "Room",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                table: "Room",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentRole");

            migrationBuilder.DropTable(
                name: "BookingParticipantRole");

            migrationBuilder.DropTable(
                name: "CalendarAppointment");

            migrationBuilder.DropTable(
                name: "FurnitureReservation");

            migrationBuilder.DropTable(
                name: "LocationFeature");

            migrationBuilder.DropTable(
                name: "EventParticipantRole");

            migrationBuilder.DropTable(
                name: "CalendarRow");

            migrationBuilder.DropTable(
                name: "BookingParticipant");

            migrationBuilder.DropTable(
                name: "CalendarView");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Furniture");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "FurnitureType");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
