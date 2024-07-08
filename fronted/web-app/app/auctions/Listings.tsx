'use client'

import React, { useEffect, useState } from 'react'
import AuctionCard from './AuctionCard';
import { Auction, PagedResult } from '@/types/index';
import AppPagination from '../components/AppPagination';
import { getData } from '../actions/auctionActions';
import Filters from './Filters';
import { useParamsStore } from '@/hooks/useParamsStore';
import { shallow } from 'zustand/shallow';
import queryString from 'query-string';
import EmptyFilter from '../components/EmptyFilter';



const Listings=()=> {
    const[data,setData]=useState<PagedResult<Auction>>();
    const params=useParamsStore(state=>({
        pageNumber: state.pageNumber,
        pageSize: state.pageSize,
        searchTerm: state.searchTerm,
        orderBy: state.orderBy,
        filterBy: state.filterBy
    }),shallow)
    const setParams=useParamsStore(state=>state.setParams);
    const url=queryString.stringifyUrl({url:``,query:params})


    const [isLoading, setIsLoading] = useState(false);

    const setPageNumber=(pageNumber:number)=>setParams({pageNumber})

    useEffect(() => {
      setIsLoading(true);
      getData(url).then((data) => {
        setData(data)
        setIsLoading(false);
      }).catch((error) => {
        console.error(error);
        setIsLoading(false);
      });
    }, [url]);
    
    if(!data) return <h3>Loading...</h3>

  return (
    <>
        <Filters></Filters>
        {data.totalCount===0 ? (
            <EmptyFilter showReset/>
        ):(
            <>
                <div className='grid grid-cols-4 gap-6'>
                    {data.results.map((auction)=>(
                        <AuctionCard auction={auction} key={auction.id}></AuctionCard>
                    ))}
                </div>
                <div className='flex justify-center mt-4'>
                    <AppPagination pageChanged={setPageNumber}currentPage={params.pageNumber} pageCount={data.pageCount}/>
                </div>
            </>
        )}
    </>
  )
}

export default Listings