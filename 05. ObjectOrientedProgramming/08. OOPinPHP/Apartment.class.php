<?php

class Apartment extends Room {
    const ROOM_EXTRAS = "[ TV, Air-conditioner, Refrigerator, Kitchen Box, Mini-Bar, Bathtub, Free Wi-fi ]";

    function __construct($roomNumber, $price)
    {
        parent::__construct(RoomType::DIAMOND, true, true, 4, $roomNumber, Apartment::ROOM_EXTRAS, $price);
    }


}