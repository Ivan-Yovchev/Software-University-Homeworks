<?php

function __autoload($className) {
    $fileName = str_replace('\\', '/', $className);
    require_once("./" . $fileName . ".class.php");
}

$rooms = array
(
    new SingleRoom(1234, 56),
    new SingleRoom(85, 99.85),
    new SingleRoom(36, 15.70),
    new Bedroom(456, 120.70),
    new Bedroom(12, 350.25),
    new Bedroom(1456, 234.90),
    new Apartment(546, 251.45),
    new Apartment(45, 125),
    new Apartment(178, 137.34),
);

$person = new Guest("Mihail", "Mihaylov", 555454);
BookingManager::bookRoom($rooms[7], new Reservation(strtotime("16.10.2014"), strtotime("18.10.2014"), $person));

$cheepBedroomsAndApartments = array_filter($rooms, function(Room $r) {
    if(!($r instanceof SingleRoom) && $r->getPrice() <= 250){
        return true;
    }
    else{
        return false;
    }
});
echo "Rooms which are Bedrooms or Apartments and cost less than 250: \r\n";
print_r($cheepBedroomsAndApartments);

$roomsWithBalconies = array_filter($rooms, function(Room $r) {
   if($r->getHasBalcony() == true){
       return true;
   }
   else{
        return false;
   }
});
echo "Rooms with balconies: \r\n";
print_r($roomsWithBalconies);

$roomsWithBathtub = array_filter(array_map(function(Room $r) {
    if(strpos(strtolower($r->getExtras()), "bathtub") !== false){
        return $r->getRoomNumber();
    }
}, $rooms), function ($r) {
    return $r != null;
});
echo "Room Numbers which have Bathtubs: \r\n";
print_r($roomsWithBathtub);

$apartmentsNotBookedInPeriod = array_filter($rooms, function($r) {

    if($r instanceof Apartment){
        $guest = new Guest("Some", "One", rand(0, PHP_INT_MAX));
        $reservation = new Reservation(strtotime("17-10-2014"), strtotime("21-10-2014"), $guest);
        try{
            $r->addReservation($reservation);
            $r->removeReservation($reservation);
            return true;
        } catch (EReservationException $ex ){
            return false;
        }
    }
    else {
        return false;
    }
});
echo "Apartments not booked in the time period 17.10.2014 - 19.10.2014: ";
print_r($apartmentsNotBookedInPeriod);




