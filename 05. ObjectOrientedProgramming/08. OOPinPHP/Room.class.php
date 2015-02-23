<?php

abstract class Room implements iReservable {
    protected $roomType;
    protected $hasRestroom;
    protected $hasBalcony;
    protected $bedCount;
    protected $roomNumber;
    protected $extras;
    protected $price;

    private $reservations;

    function __construct($roomType, $hasRestroom, $hasBalcony, $bedCount, $roomNumber, $extras, $price)
    {
        $this->setRoomType($roomType);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setBedCount($bedCount);
        $this->setRoomNumber($roomNumber);
        $this->setExtras($extras);
        $this->setPrice($price);
        $this->setReservations();
    }

    public function setReservations()
    {
        $this->reservations = array();
    }

    public function getRoomType()
    {
        return $this->roomType;
    }

    private function setRoomType($roomType)
    {
        $this->roomType = $roomType;
    }

    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    private function setHasRestroom($hasRestroom)
    {
        $this->hasRestroom = $hasRestroom;
    }

    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    private function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    public function getBedCount()
    {
        return $this->bedCount;
    }

    private function setBedCount($bedCount)
    {
        $this->bedCount = $bedCount;
    }

    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    private function setRoomNumber($roomNumber)
    {
        if($roomNumber <= 0){
            throw new InvalidArgumentException("Room number cannot be negative or zero");
        }
        else{
            $this->roomNumber = $roomNumber;
        }
    }

    public function getExtras()
    {
        return $this->extras;
    }

    private function setExtras($extras)
    {
        $this->extras = $extras;
    }

    public function getPrice()
    {
        return $this->price;
    }

    private function setPrice($price)
    {
        if($price <= 0){
            throw new InvalidArgumentException("Price cannot be zero or negative");
        }
        else{
            $this->price = $price;
        }
    }

    function addReservation(Reservation $reservation)
    {
        if(count($this->reservations) == 0){
            array_push($this->reservations, $reservation);
        }
        else{
            $isReserved = false;

            foreach($this->reservations as $reserv){
                if(!($reserv->getEndDate() < $reservation->getStartDate() || $reserv->getStartDate() > $reservation->getEndDate())){
                    $isReserved = true;
                    break;
                }
            }

            if($isReserved == true){
                throw new EReservationException("A Reservation already exists in this period");
            }
            else{
                array_push($this->reservations, $reservation);
            }
        }
    }

    function removeReservation($reservation)
    {
        if(in_array($reservation, $this->reservations)){
            $key = array_search($reservation, $this->reservations);
            unset($this->reservations[$key]);
        }
        else{
            throw new InvalidArgumentException("Reservation does not exist");
        }
    }

    function __toString()
    {
        $roomType = "";
        switch($this->roomType){
            case 1: $roomType = "Standard"; break;
            case 2: $roomType = "Gold"; break;
            case 3: $roomType = "Diamond"; break;
        }

        $hasRestroom = "No";
        if($this->hasRestroom == true){
            $hasRestroom = "Yes";
        }

        $hasBalcony = "No";
        if($this->hasBalcony == true){
            $hasBalcony = "Yes";
        }

        $price = number_format((float)$this->price, 2, '.', '');;
        return
            "Room Type: $roomType, " .
            "Has Restroom: $hasRestroom, " .
            "Has Balcony: $hasBalcony, " .
            "Bed Count: $this->bedCount, " .
            "Room Number: $this->roomNumber, " .
            "Extras: $this->extras, " .
            "Price: $price";
    }
}