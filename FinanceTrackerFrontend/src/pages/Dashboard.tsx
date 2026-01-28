import { useEffect } from "react"
import { useState } from "react";

import type { Spending } from "../models/spending";

// api
import { getSpendings } from "../api/spendings";

export default function DashboardPage() {
    const [userSpendings, setUserSpendings] = useState<Spending[]>([]);

    useEffect(() => {
        const init = async () => {
            setUserSpendings(await getSpendings())
        };

        init();
    }, [])

    return (
        <>
            <div className="flex gap-4 m-30 h-64">
                <div className="containercolor containerround flex-[1]">test</div>
                <div className="containercolor containerround flex-[6]">
                    {
                        userSpendings.map(spending => (
                            <>
                                <div>{spending.name}</div>
                                <div>₱{spending.amount}</div> 
                            </>
                        ))
                    }
                </div>
            </div>
        </>
    )
}