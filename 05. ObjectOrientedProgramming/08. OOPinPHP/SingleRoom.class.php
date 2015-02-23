<?php

class SingleRoom extends Room {

    const ROOM_EXTRAS = "[ TV, Air-Conditioner ]";

    function __construct($roomNumber, $price)
    {
        parent::__construct(RoomType::STANDARD, true, false, 1, $roomNumber, SingleRoom::ROOM_EXTRAS, $price);
    }
}