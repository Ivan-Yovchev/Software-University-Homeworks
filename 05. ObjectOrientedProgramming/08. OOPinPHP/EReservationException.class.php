<?php

class EReservationException  extends Exception {
    public function __construct($paramName) {
        parent::__construct("Reservation already exists in this period", 231);
    }
}