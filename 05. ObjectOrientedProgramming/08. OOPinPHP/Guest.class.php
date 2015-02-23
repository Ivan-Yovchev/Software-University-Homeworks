<?php

class Guest {
    private $firstName;
    private $lastName;
    private $egn;
    private static $uniqueIDs = [];

    function __construct($firstName, $lastName, $egn)
    {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setEgn($egn);
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    private function setFirstName($firstName)
    {
        if(strlen($firstName) == 0 || $firstName == null){
            throw new InvalidArgumentException("First name cannot be null or empty");
        }
        else {
            $this->firstName = $firstName;
        }
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    private function setLastName($lastName)
    {
        if(strlen($lastName) == 0 || $lastName == null){
            throw new InvalidArgumentException("Last name cannot be null or empty");
        }
        else {
            $this->lastName = $lastName;
        }
    }

    public function getEgn()
    {
        return $this->egn;
    }

    private function setEgn($egn)
    {
        if(strlen($egn) == 0 || $egn == null){
            throw new InvalidArgumentException("EGN cannot be null or empty");
        }
        else if (in_array($egn, Guest::$uniqueIDs)) {
            throw new InvalidArgumentException("A person with this EGN already exists");
        }
        else {
            $this->egn = $egn;
            Guest::$uniqueIDs[] = $egn;
        }
    }

    function __toString()
    {
        return "Name: $this->firstName $this->lastName, EGN: $this->egn";
    }


}