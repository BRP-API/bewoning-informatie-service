#!/bin/bash

npx nswag run src/Bewoning.Data.Mock/Server.nswag
npx nswag run src/Bewoning.Informatie.Service/DataTransferObjects.nswag
npx nswag run src/Bewoning.Informatie.Service/GbaDataTransferObjects.nswag
