<?php

class Bedroom extends Room {

    const ROOM_EXTRAS = "[ TV, Air-Conditioner, Refrigerator, Mini-Bar, Bathtub ]";

    function __construct($roomNumber, $price)
    {
        parent::__construct(RoomType::GOLD, true, true, 2, $roomNumber, Bedroom::ROOM_EXTRAS, $price);
    }
}