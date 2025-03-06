using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampPlanner.Migrations
{
    /// <inheritdoc />
    public partial class EditDeleteSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizations_OrganizationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
              name: "FK_Event_Organization_OrganizationId",
              table: "Event",
              column: "OrganizationId",
              principalTable: "Organization",
              principalColumn: "Id",
              onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Events_EventId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizations_OrganizationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentRoles_Appointments_AppointmentId",
                table: "AppointmentRoles",
                column: "AppointmentId",
                principalTable: "Appointments",
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
                name: "FK_BookingParticipants_Bookings_BookingId",
                table: "BookingParticipants",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarViews_Events_EventId",
                table: "CalendarViews",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizations_OrganizationId",
                table: "Events",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFeatures_Locations_LocationId",
                table: "LocationFeatures",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
