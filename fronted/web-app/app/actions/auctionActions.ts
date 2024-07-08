'use server'

import { Auction, PagedResult } from "@/types";

export const getData=async(query:string):Promise<PagedResult<Auction>>=>{
    const res=await fetch(`http://localhost:6001/search${query}`)

    if(!res){
        throw new Error("failed to fetch data")
    }

    return res.json();
}