<?php

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, $guest)
    {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getStartDate()
    {
        return $this->startDate;
    }

    private function setStartDate($startDate)
    {
        $this->startDate = $startDate;
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    private function setEndDate($endDate)
    {
        if($endDate <= $this->startDate){
            throw new InvalidArgumentException("End date cannot be before or the same as start date");
        }
        else{
            $this->endDate = $endDate;
        }
    }

    public function getGuest()
    {
        return $this->guest;
    }

    private function setGuest($guest)
    {
        $this->guest = $guest;
    }

    function __toString()
    {
        $startDate = date("d-M-Y", $this->startDate);
        $endDate = date("d-M-Y", $this->endDate);
        return "Start Date: $startDate, End Date: $endDate, Guest[ $this->guest ]";
    }


}