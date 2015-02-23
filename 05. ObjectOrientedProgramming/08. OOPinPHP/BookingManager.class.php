<?php

class BookingManager {
    static function bookRoom(Room $room, Reservation $reservation){
        try{
            $room->addReservation($reservation);

            $startDate = date("d.m.Y", $reservation->getStartDate());
            $endDate = date("d.m.Y", $reservation->getEndDate());

            echo
                "Room <strong>" . $room->getRoomNumber() . "</strong>" .
                " successfully booked for " .
                "<strong>" . $reservation->getGuest()->getFirstName() . " " .
                $reservation->getGuest()->getLastName() . "</strong>" .
                " from <time>" . $startDate . "</time> to " .
                "<time>" . $endDate . "</time>!\r\n";
        }
        catch (Exception $e){
            echo $e->getMessage();
        }
    }
}