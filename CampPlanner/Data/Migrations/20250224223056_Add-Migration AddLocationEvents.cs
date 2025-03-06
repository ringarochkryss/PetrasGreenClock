using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationAddLocationEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Events_EventId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRole_Appointment_AppointmentId",
                table: "AppointmentRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRole_BookingParticipant_BookingParticipantId",
                table: "AppointmentRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRole_EventParticipantRole_EventParticipantRoleId",
                table: "AppointmentRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Events_EventId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipant_Booking_BookingId",
                table: "BookingParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipant_Furniture_FurnitureId",
                table: "BookingParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipant_Person_PersonId",
                table: "BookingParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipant_Room_RoomId",
                table: "BookingParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipantRole_BookingParticipant_BookingParticipantId",
                table: "BookingParticipantRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_Locations_LocationId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarAppointment_Appointment_AppointmentId",
                table: "CalendarAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_BookingParticipant_BookingParticipantId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_CalendarView_CalendarViewId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_Room_RoomId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarView_Events_EventId",
                table: "CalendarView");

            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_Room_RoomId",
                table: "Furniture");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationFeature_Locations_LocationId",
                table: "LocationFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Appointment_AppointmentId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationFeature",
                table: "LocationFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarView",
                table: "CalendarView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingParticipant",
                table: "BookingParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentRole",
                table: "AppointmentRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "LocationFeature",
                newName: "LocationFeatures");

            migrationBuilder.RenameTable(
                name: "CalendarView",
                newName: "CalendarViews");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameTable(
                name: "BookingParticipant",
                newName: "BookingParticipants");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "AppointmentRole",
                newName: "AppointmentRoles");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Room_BuildingId",
                table: "Rooms",
                newName: "IX_Rooms_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_AppointmentId",
                table: "Rooms",
                newName: "IX_Rooms_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationFeature_LocationId",
                table: "LocationFeatures",
                newName: "IX_LocationFeatures_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarView_EventId",
                table: "CalendarViews",
                newName: "IX_CalendarViews_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_LocationId",
                table: "Buildings",
                newName: "IX_Buildings_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipant_RoomId",
                table: "BookingParticipants",
                newName: "IX_BookingParticipants_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipant_PersonId",
                table: "BookingParticipants",
                newName: "IX_BookingParticipants_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipant_FurnitureId",
                table: "BookingParticipants",
                newName: "IX_BookingParticipants_FurnitureId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipant_BookingId",
                table: "BookingParticipants",
                newName: "IX_BookingParticipants_BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_EventId",
                table: "Bookings",
                newName: "IX_Bookings_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRole_EventParticipantRoleId",
                table: "AppointmentRoles",
                newName: "IX_AppointmentRoles_EventParticipantRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRole_BookingParticipantId",
                table: "AppointmentRoles",
                newName: "IX_AppointmentRoles_BookingParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRole_AppointmentId",
                table: "AppointmentRoles",
                newName: "IX_AppointmentRoles_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_EventId",
                table: "Appointments",
                newName: "IX_Appointments_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationFeatures",
                table: "LocationFeatures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarViews",
                table: "CalendarViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingParticipants",
                table: "BookingParticipants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentRoles",
                table: "AppointmentRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRoles_BookingParticipants_BookingParticipantId",
                table: "AppointmentRoles",
                column: "BookingParticipantId",
                principalTable: "BookingParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRoles_EventParticipantRole_EventParticipantRoleId",
                table: "AppointmentRoles",
                column: "EventParticipantRoleId",
                principalTable: "EventParticipantRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipantRole_BookingParticipants_BookingParticipantId",
                table: "BookingParticipantRole",
                column: "BookingParticipantId",
                principalTable: "BookingParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipants_Furniture_FurnitureId",
                table: "BookingParticipants",
                column: "FurnitureId",
                principalTable: "Furniture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipants_Person_PersonId",
                table: "BookingParticipants",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipants_Rooms_RoomId",
                table: "BookingParticipants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Locations_LocationId",
                table: "Buildings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarAppointment_Appointments_AppointmentId",
                table: "CalendarAppointment",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_BookingParticipants_BookingParticipantId",
                table: "CalendarRow",
                column: "BookingParticipantId",
                principalTable: "BookingParticipants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_CalendarViews_CalendarViewId",
                table: "CalendarRow",
                column: "CalendarViewId",
                principalTable: "CalendarViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_Rooms_RoomId",
                table: "CalendarRow",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_Rooms_RoomId",
                table: "Furniture",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Appointments_AppointmentId",
                table: "Rooms",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRoles_BookingParticipants_BookingParticipantId",
                table: "AppointmentRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRoles_EventParticipantRole_EventParticipantRoleId",
                table: "AppointmentRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipantRole_BookingParticipants_BookingParticipantId",
                table: "BookingParticipantRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Furniture_FurnitureId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Person_PersonId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Rooms_RoomId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Locations_LocationId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarAppointment_Appointments_AppointmentId",
                table: "CalendarAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_BookingParticipants_BookingParticipantId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_CalendarViews_CalendarViewId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_Rooms_RoomId",
                table: "CalendarRow");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_Rooms_RoomId",
                table: "Furniture");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Appointments_AppointmentId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationFeatures",
                table: "LocationFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarViews",
                table: "CalendarViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingParticipants",
                table: "BookingParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentRoles",
                table: "AppointmentRoles");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "LocationFeatures",
                newName: "LocationFeature");

            migrationBuilder.RenameTable(
                name: "CalendarViews",
                newName: "CalendarView");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "BookingParticipants",
                newName: "BookingParticipant");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameTable(
                name: "AppointmentRoles",
                newName: "AppointmentRole");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildingId",
                table: "Room",
                newName: "IX_Room_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_AppointmentId",
                table: "Room",
                newName: "IX_Room_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationFeatures_LocationId",
                table: "LocationFeature",
                newName: "IX_LocationFeature_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarViews_EventId",
                table: "CalendarView",
                newName: "IX_CalendarView_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_LocationId",
                table: "Building",
                newName: "IX_Building_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EventId",
                table: "Booking",
                newName: "IX_Booking_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipants_RoomId",
                table: "BookingParticipant",
                newName: "IX_BookingParticipant_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipants_PersonId",
                table: "BookingParticipant",
                newName: "IX_BookingParticipant_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipants_FurnitureId",
                table: "BookingParticipant",
                newName: "IX_BookingParticipant_FurnitureId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingParticipants_BookingId",
                table: "BookingParticipant",
                newName: "IX_BookingParticipant_BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_EventId",
                table: "Appointment",
                newName: "IX_Appointment_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRoles_EventParticipantRoleId",
                table: "AppointmentRole",
                newName: "IX_AppointmentRole_EventParticipantRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRoles_BookingParticipantId",
                table: "AppointmentRole",
                newName: "IX_AppointmentRole_BookingParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentRoles_AppointmentId",
                table: "AppointmentRole",
                newName: "IX_AppointmentRole_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationFeature",
                table: "LocationFeature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarView",
                table: "CalendarView",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingParticipant",
                table: "BookingParticipant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentRole",
                table: "AppointmentRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Events_EventId",
                table: "Appointment",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRole_Appointment_AppointmentId",
                table: "AppointmentRole",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRole_BookingParticipant_BookingParticipantId",
                table: "AppointmentRole",
                column: "BookingParticipantId",
                principalTable: "BookingParticipant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRole_EventParticipantRole_EventParticipantRoleId",
                table: "AppointmentRole",
                column: "EventParticipantRoleId",
                principalTable: "EventParticipantRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Events_EventId",
                table: "Booking",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipant_Booking_BookingId",
                table: "BookingParticipant",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipant_Furniture_FurnitureId",
                table: "BookingParticipant",
                column: "FurnitureId",
                principalTable: "Furniture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipant_Person_PersonId",
                table: "BookingParticipant",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipant_Room_RoomId",
                table: "BookingParticipant",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipantRole_BookingParticipant_BookingParticipantId",
                table: "BookingParticipantRole",
                column: "BookingParticipantId",
                principalTable: "BookingParticipant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Locations_LocationId",
                table: "Building",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarAppointment_Appointment_AppointmentId",
                table: "CalendarAppointment",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_BookingParticipant_BookingParticipantId",
                table: "CalendarRow",
                column: "BookingParticipantId",
                principalTable: "BookingParticipant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_CalendarView_CalendarViewId",
                table: "CalendarRow",
                column: "CalendarViewId",
                principalTable: "CalendarView",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_Room_RoomId",
                table: "CalendarRow",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarView_Events_EventId",
                table: "CalendarView",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_Room_RoomId",
                table: "Furniture",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFeature_Locations_LocationId",
                table: "LocationFeature",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Appointment_AppointmentId",
                table: "Room",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
